using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Drawing;

namespace Fresh
{
    public partial class MainForm : XtraForm
    {
        int gN=0;
        SampleDataSource dataSource;
        Dictionary<SampleDataGroup, PageGroup> groupsItemDetailPage;
        public MainForm()
        {
            InitializeComponent();
            windowsUIView.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False;
            dataSource = new SampleDataSource();
            groupsItemDetailPage = new Dictionary<SampleDataGroup, PageGroup>();
            CreateLayout();
        }
        /// <summary>
        /// 创建整个界面
        /// </summary>
        void CreateLayout()
        {
            foreach (SampleDataGroup group in dataSource.Data.Groups)
            {
                tileContainer.Buttons.Add(new DevExpress.XtraBars.Docking2010.WindowsUIButton(group.Title, null, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, null, true, -1, true, null, false, false, true, null, group, -1, false, false));
                PageGroup pageGroup = new PageGroup();
                pageGroup.Parent = tileContainer;
                pageGroup.Caption = group.Title;
                windowsUIView.ContentContainers.Add(pageGroup);
                groupsItemDetailPage.Add(group, CreateGroupItemDetailPage(group, pageGroup));
                foreach (SampleDataItem item in group.Items)
                {
                    ItemDetailPage itemDetailPage = new ItemDetailPage(item);
                    itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    BaseDocument document = windowsUIView.AddDocument(itemDetailPage);
                    document.Caption = item.Title;
                    pageGroup.Items.Add(document as Document);
                    CreateTile(document as Document, item).ActivationTarget = pageGroup;
                }
            }
            windowsUIView.ActivateContainer(tileContainer);
            tileContainer.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(buttonClick);
        }
        Tile CreateTile(Document document, SampleDataItem item)
        {
            Tile tile = new Tile();
            tile.Document = document;
            tile.Group = item.GroupName;
            tile.Tag = item;
            tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.BottomLeft, Point.Empty, 9));
            tile.Elements.Add(CreateTileItemElement(item.Subtitle, TileItemContentAlignment.Manual, new Point(0, 100), 12));
            tile.Appearances.Selected.BackColor = tile.Appearances.Hovered.BackColor = tile.Appearances.Normal.BackColor = Color.FromArgb(120, 120, 120);
            tile.Appearances.Selected.BorderColor = tile.Appearances.Hovered.BorderColor = tile.Appearances.Normal.BorderColor = Color.FromArgb(120, 120, 120);
            tile.Click += new TileClickEventHandler(tile_Click);
            windowsUIView.Tiles.Add(tile);
            tileContainer.Items.Add(tile);
            return tile;
        }
        TileItemElement CreateTileItemElement(string text, TileItemContentAlignment alignment, Point location, float fontSize)
        {
            TileItemElement element = new TileItemElement();
            element.TextAlignment = alignment;
            if (!location.IsEmpty) element.TextLocation = location;
            element.Text = text;
            return element;
        }
        void tile_Click(object sender, TileClickEventArgs e)
        {
            PageGroup page = ((e.Tile as Tile).ActivationTarget as PageGroup);
            if (page != null)
            {
                page.Parent = tileContainer;
                page.SetSelected((e.Tile as Tile).Document);
            }
        }
        PageGroup CreateGroupItemDetailPage(SampleDataGroup group, PageGroup child)
        {
            GroupDetailPage page = new GroupDetailPage(group, child);
            if (gN == 0)
            {
                page.browse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.find.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.analyse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.visualized.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.algorithm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.el.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            if (gN == 1)
            {
                
                page.browse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.find.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.analyse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.visualized.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.algorithm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.el.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.Tab.SelectedTabPageIndex = 1;
            }
            if (gN == 2)
            {
                page.browse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.find.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.analyse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.visualized.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.algorithm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.el.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.Tab.SelectedTabPageIndex = 1;
            }
            if (gN == 3)
            {
                page.browse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.find.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.analyse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.visualized.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.algorithm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.el.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.Tab.SelectedTabPageIndex = 1;
            }
            if (gN == 4)
            {
                page.browse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.find.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.analyse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.visualized.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.algorithm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.el.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.Tab.SelectedTabPageIndex = 1;
            }
            if (gN == 5)
            {
                page.browse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.find.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.analyse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.visualized.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.algorithm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                page.el.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                page.Tab.SelectedTabPageIndex = 1;
            }

            PageGroup pageGroup = page.PageGroup;
            BaseDocument document = windowsUIView.AddDocument(page);
            pageGroup.Parent = tileContainer;
            pageGroup.Properties.ShowPageHeaders = DevExpress.Utils.DefaultBoolean.False;
            pageGroup.Items.Add(document as Document);
            windowsUIView.ContentContainers.Add(pageGroup);
            windowsUIView.ActivateContainer(pageGroup);

            gN++;

            return pageGroup;
        }
        void buttonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            SampleDataGroup tileGroup = (e.Button.Properties.Tag as SampleDataGroup);
            
            if (tileGroup.Name == "地图浏览功能")
            {
                XtraMessageBox.Show("地图浏览功能");
                
            }

            if (tileGroup != null)
            {
                windowsUIView.ActivateContainer(groupsItemDetailPage[tileGroup]);
            }
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            
        }
    }
}
