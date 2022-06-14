using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using SuperMap.Mapping;
using SuperMap.UI;
using SuperMap.Data;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Windows.Forms;

namespace Fresh
{
    internal interface IFind
    {
        WindowsUIView WindowsUIView
        {
            get;
            set;
        }
        //图查属性
        void QueryProperty(MapControl mapControl, DataGridView dataGridView);
        //属性查图
        void SQLQuery(TextEdit textEdit,MapControl mapControl);
    }

    public class Find : IFind
    {
        //构造函数
        public Find()
        {

        }
        public Find(MapControl mapControl)
        {
            this.mapControl = mapControl;
        }
        //属性
        MapControl mapControl;
        public MapControl MapControl
        {
            get { return mapControl; }
            set { mapControl = value; }
        }
        WindowsUIView windowsUIView;
        public WindowsUIView WindowsUIView
        {
            get { return windowsUIView; }
            set { windowsUIView = value; }
        }
        String tableName = null;
        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }


        //方法
        /// <summary>
        /// 图查属性
        /// </summary>
        /// <param name="mapControl"></param>
        /// <param name="dataGridView"></param>
        public void QueryProperty(MapControl mapControl, DataGridView dataGridView)
        {
            //选择对象
            mapControl.Action = SuperMap.UI.Action.Select2;
            //获取选择集
            Selection[] selection = mapControl.Map.FindSelection(true);
            
            //判断选择集是否为空
            if(selection==null||selection.Length == 0)
            {
                MessageBox.Show("请选择要查询属性的空间对象");
                return;
            }
            TableName = selection[0].Dataset.Name+"图层中的相关信息：";
            //将选择集转换为记录
            Recordset recordset = selection[0].ToRecordset();
            
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            for(int i = 0; i < recordset.FieldCount; i++)
            {
                //定义并获得字段名称
                String fileName = recordset.GetFieldInfos()[i].Name;

                //将得到的字段名称添加到dataGridView列中
                dataGridView.Columns.Add(fileName, fileName);
            }

            //初始化row
            DataGridViewRow row = null;

            //根据选中记录的个数，将选中对象的信息添加到dataGridView中显示
            while(!recordset.IsEOF)
            {
                row = new DataGridViewRow();
                for(int i = 0; i < recordset.FieldCount; i++)
                {
                    //定义并获得字段值
                    Object fieldValue = recordset.GetFieldValue(i);

                    //将字段值添加到dataGridView中对应的位置
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();

                    if (fieldValue != null)
                    {
                        cell.ValueType = fieldValue.GetType();
                        cell.Value = fieldValue;
                    }
                    row.Cells.Add(cell);
                }
                dataGridView.Rows.Add(row);
                recordset.MoveNext();
            }
            dataGridView.Update();
            recordset.Dispose();
        }

        //属性查图
        public void SQLQuery(TextEdit textEdit,MapControl mapControl)
        {
            //判断TextEdit输入的内容是否为空
            if (textEdit.Text.Length == 0 || textEdit.Text == "请输入您要查询的门店名称...")
            {
                MessageBox.Show("查询信息不能为空");
                return;
            }
            //定义图层个数
            Int32 layerCount = mapControl.Map.Layers.Count;
            //判断当前地图窗口中是否有打开的图层
            if (layerCount == 0)
            {
                MessageBox.Show("请先打开一个矢量数据集！");
                return ;
            }
            //定义查询条件
            QueryParameter queryParameter = new QueryParameter();
            queryParameter.AttributeFilter = textEdit.Text;
            queryParameter.CursorType = CursorType.Static;

            Boolean hasGeometry = false;
            //遍历每一个图层，实现多图层查询
            foreach(Layer layer in mapControl.Map.Layers)
            {
                //得到矢量数据集并强制转换为矢量数据类型
                DatasetVector dataset = layer.Dataset as DatasetVector;
                if (dataset == null)
                {
                    continue;
                }
                //通过查询条件对矢量数据集进行查询，从数据集中查询出属性数据
                Recordset recordset = dataset.Query(queryParameter);
                //判断是否有查询结果
                if (recordset.RecordCount > 0)
                {
                    hasGeometry = true;
                }
                //把查询得到的数据加入到选择集中（使其高亮显示）
                Selection selection = layer.Selection;
                selection.FromRecordset(recordset);
                recordset.Dispose();
                //没有查询结果，弹出提示
                if(!hasGeometry)
                {
                    MessageBox.Show("没有符合查询条件的结果或查询条件有误，请重新确认后查询！"); 
                }

                //当可创建对象使用完毕后，使用Dispose来释放占用的内部资源
                queryParameter.Dispose();
                //刷新地图窗口显示
                mapControl.Refresh();
                hasGeometry = false;
            }
        }
    }
}
