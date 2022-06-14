using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using SuperMap.UI;
using SuperMap.Mapping;
using SuperMap.Data;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010.Views;
using System.Drawing;

namespace Fresh
{
    interface Iv
    {
        LayoutControlGroup browse { get; set; }
        LayoutControlGroup find { get; set; }
        LayoutControlGroup analyse { get; set; }
        LayoutControlGroup visualized { get; set; }
        LayoutControlGroup algorithm { get; set; }
        LayoutControlGroup el { get; set; }

        TabbedControlGroup Tab { get; set; }

    }
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public partial class GroupDetailPage : XtraUserControl, Iv
    {
        public LayoutControlGroup browse
        {
            get { return Browse; }
            set { Browse = value; }
        }

        public LayoutControlGroup find
        {
            get { return Find; }
            set { Find = value; }
        }

        public LayoutControlGroup analyse
        {
            get { return Analyse; }
            set
            {
                Analyse = value;
            }
        }

        public LayoutControlGroup visualized
        {
            get { return Visualized; }
            set
            {
                Visualized = value;
            }
        }

        public LayoutControlGroup algorithm
        {
            get { return Algorithm; }
            set
            {
                Algorithm = value;
            }
        }

        public LayoutControlGroup el
        {
            get { return Else; }
            set { Else = value; }
        }
        public TabbedControlGroup Tab
        {
            get { return tab; }
            set { tab = value; }
        }

        PageGroup pageGroupCore;
        public PageGroup PageGroup { get { return pageGroupCore; } }
        public GroupDetailPage(SampleDataGroup dataGroup, PageGroup child)
        {
            InitializeComponent();
            pageGroupCore = new PageGroup();
            pageGroupCore.Caption = dataGroup.Title;
            imageControl.Image = DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(dataGroup.ImagePath, typeof(MainForm).Assembly);
            labelSubtitle.Text = dataGroup.Subtitle;
            labelDescription.Text = dataGroup.Description;
            CreateLayout(dataGroup, child);
        }
        void CreateLayout(SampleDataGroup dataGroup, PageGroup child)
        {
            for (int i = 0; i < dataGroup.Items.Count; i++)
                CreateLayoutCore(dataGroup.Items[i], child, i);
        }
        void CreateLayoutCore(SampleDataItem item, PageGroup child, int index)
        {
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            DevExpress.XtraLayout.LayoutControlItem layoutTileItem = new DevExpress.XtraLayout.LayoutControlItem();

            layoutTileItem.Location = new System.Drawing.Point(0, 0);
            layoutTileItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutTileItem.TextSize = new System.Drawing.Size(0, 0);
            layoutTileItem.TextToControlDistance = 0;
            layoutTileItem.TextVisible = false;
            layoutControlGroup2.Add(layoutTileItem);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            //Browse b = new Browse(workspace1,mapControl1,openFileDialog1);
            //b.Open();

        }

        private void GroupDetailPage_Load(object sender, System.EventArgs e)
        {
            Browse b = new Browse(workspace1, mapControl1);
            b.Open();
        }

        private void GroupDetailPage_Leave(object sender, System.EventArgs e)
        {
            //mapControl1.Dispose();
            //workspace1.Close();
            //workspace1.Dispose();
        }

        /// <summary>
        /// 漫游
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, System.EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Pan;
        }
        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, System.EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomIn;
        }
        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, System.EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomOut;
        }
        /// <summary>
        /// 自由缩放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, System.EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomFree;
        }
        /// <summary>
        /// 地图全幅显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton6_Click(object sender, System.EventArgs e)
        {
            mapControl1.Map.ViewEntire();
        }

        //提示信息
        private string Notes = "请输入您要查询的门店名称...";
        /// <summary>
        /// 属性查图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton8_Click(object sender, System.EventArgs e)
        {
            Find f = new Find();
            f.SQLQuery(textEdit1,mapControl1);
        }

        
        private void textEdit1_Leave(object sender, System.EventArgs e)
        {
            //失去焦点 重新显示
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                textEdit1.ForeColor = Color.DarkGray;
                textEdit1.Text = Notes;

            }
        }

        private void textEdit1_Enter(object sender, System.EventArgs e)
        {
            if(textEdit1.Text==Notes)
            {
                textEdit1.ForeColor = Color.Black;
                textEdit1.Text = "";
            }
        }

        /// <summary>
        /// 单击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapControl1_Click(object sender, System.EventArgs e)
        {
            //QueryForm qf = new QueryForm();
            //Find f = new Find();
            //DataGridView dataGridView1 = qf.DataGridView;
            //f.QueryProperty(mapControl1, dataGridView1);
            //qf.ShowDialog();
        }

        /// <summary>
        /// 双击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapControl1_DoubleClick(object sender, System.EventArgs e)
        {
            QueryForm qf = new QueryForm();
            Find f = new Find();
            DataGridView dataGridView1 = qf.DataGridView;
            f.QueryProperty(mapControl1, dataGridView1);
            qf.ShowDialog();
        }

    }
}
