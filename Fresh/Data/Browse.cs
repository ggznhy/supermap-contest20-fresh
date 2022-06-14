using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMap.UI;
using SuperMap.Mapping;
using SuperMap.Data;
using System.Windows.Forms;

namespace Fresh
{
    interface IBrowse
    {
        Workspace Workspace { get; set; }
        MapControl MapControl { get; set; }
        OpenFileDialog OpenFileDialog { get; set; }
        //打开地图
        void Open();
        void ZoomIn();
    }
    internal class Browse : IBrowse
    {
        //属性
        Workspace workspace;
        public Workspace Workspace
        {
            get { return workspace; }
            set { workspace = value; }

        }
        MapControl mapControl;
        public MapControl MapControl
        {
            get { return mapControl; }
            set { mapControl = value; }
        }
        OpenFileDialog openfileDialog;
        public OpenFileDialog OpenFileDialog
        {
            get { return openfileDialog; }
            set { openfileDialog = value; }
        }
        //构造函数
        public Browse()
        {

        }
        public Browse(Workspace workspace, MapControl mapControl)
        {
            this.workspace = workspace;
            this.mapControl = mapControl;
        }
        public Browse(Workspace workspace, MapControl mapControl, OpenFileDialog openFileDialog)
        {
            this.workspace = workspace;
            this.mapControl = mapControl;
            this.openfileDialog = openFileDialog;
        }

        //打开工作空间并且加载地图的方法
        public void Open()
        {
            /*
            //设置公用打开对话框
            openfileDialog.Filter = "SuperMap 工作空间文件(*.smwu)|*.smwu";
            //判断打开的结果，如果打开就执行下列操作

            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                //避免连续打开工作空间导致程序异常
                mapControl.Map.Close();
                workspace.Close();
                mapControl.Map.Refresh();
                //定义打开工作空间文件名
                String fileName = openfileDialog.FileName;
                //打开工作空间文件
                WorkspaceConnectionInfo connectionInfo = new WorkspaceConnectionInfo(fileName);
                //打开工作空间
                workspace.Open(connectionInfo);
                //建立MapControl与WorkSpace的连接
                mapControl.Map.Workspace = workspace;
                //判断工作空间中是否有地图
                if (workspace.Maps.Count == 0)
                {
                    MessageBox.Show("当前工作空间中不存在地图");
                    return;
                }
                //通过名称打开工作空间中的地图
                mapControl.Map.Open("ChengduMap");
                //刷新地图窗口

            }
            */

            //***************************************************************************************************************
            //自动加载地图
            
            try
            {
                //定义打开工作空间文件名
                //String fileName = "..\\..\\..\\..\\2成果数据\\ChengduFresh.smwu";
                String fileName = "D:\\Super\\PD+2vpbc3VaLl\\2成果数据\\ChengduFresh.smwu";
                //打开工作空间文件
                WorkspaceConnectionInfo connectionInfo = new WorkspaceConnectionInfo(fileName);
                //打开工作空间
                workspace.Open(connectionInfo);
                //建立MapControl与WorkSpace的连接
                mapControl.Map.Workspace = workspace;
                //判断工作空间中是否有地图
                if (workspace.Maps.Count == 0)
                {
                    MessageBox.Show("当前工作空间中不存在地图");
                    return;
                }
                //通过名称打开工作空间中的地图
                mapControl.Map.Open("ChengduMap");
                //刷新地图窗口
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

            //throw new NotImplementedException();
        }

        /// <summary>
        /// 定位到主城区方便查看
        /// </summary>
        public void ZoomIn()
        {

        }

    }
}
