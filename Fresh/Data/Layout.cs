using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item WindowsUIViewApplications.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace Fresh
{
    /// <summary>
    /// Base class for <see cref="SampleDataItem"/> and <see cref="SampleDataGroup"/> that
    /// defines properties common to both.
    /// </summary>
    public class SampleDataCommon
    {
        string subtitleCore, imagePathCore, descriptionCore, titleCore;
        public string Title { get { return titleCore; } }
        public string Subtitle { get { return subtitleCore; } }
        public string ImagePath { get { return imagePathCore; } }
        public string Description { get { return descriptionCore; } }
        public SampleDataCommon(string title, string subtitle, string imagePath, string description)
        {
            titleCore = title;
            subtitleCore = subtitle;
            imagePathCore = imagePath;
            descriptionCore = description;
        }
        public SampleDataCommon() { }
    }
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SampleDataCommon
    {
        string contentCore, groupNameCore;
        public SampleDataItem(string title, string subtitle, string imagePath, string description, string content, string groupName)
            : base(title, subtitle, imagePath, description)
        {
            contentCore = content;
            groupNameCore = groupName;
        }
        public string Content { get { return contentCore; } }
        public string GroupName { get { return groupNameCore; } }
    }
    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup : SampleDataCommon
    {
        string nameCore;
        Collection<SampleDataItem> itemsCore;
        public SampleDataGroup(string name)
            : base()
        {
            this.nameCore = name;
            itemsCore = new Collection<SampleDataItem>();
        }
        public SampleDataGroup(string name, string title, string subtitle, string imagePath, string description)
            : base(title, subtitle, imagePath, description)
        {
            this.nameCore = name;
            itemsCore = new Collection<SampleDataItem>();
        }
        public string Name { get { return nameCore; } }
        public Collection<SampleDataItem> Items { get { return itemsCore; } }
        public bool AddItem(SampleDataItem tile)
        {
            if (!itemsCore.Contains(tile))
            {
                itemsCore.Add(tile);
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Generic data model.
    /// </summary>
    internal class SampleDataModel
    {
        Collection<SampleDataGroup> groupsCore;
        public SampleDataModel()
        {
            groupsCore = new Collection<SampleDataGroup>();
        }
        public Collection<SampleDataGroup> Groups { get { return groupsCore; } }
        SampleDataGroup GetGroup(string name)
        {
            foreach (var group in groupsCore)
                if (group.Name == name) return group;
            return null;
        }
        public bool AddItem(SampleDataItem tile)
        {
            if (tile == null) return false;
            string groupName = tile.GroupName == null ? "" : tile.GroupName;
            SampleDataGroup thisGroup = GetGroup(groupName);
            if (thisGroup == null)
            {
                thisGroup = new SampleDataGroup(groupName);
                groupsCore.Add(thisGroup);
            }
            return thisGroup.AddItem(tile);
        }
        bool ContainsGroup(string name)
        {
            return GetGroup(name) != null;
        }
        public void CreateGroup(string name, string title, string subtitle, string imagePath, string description)
        {
            if (ContainsGroup(name)) return;
            SampleDataGroup group = new SampleDataGroup(name, title, subtitle, imagePath, description);
            groupsCore.Add(group);
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    internal class SampleDataSource
    {
        SampleDataModel dataCore;
        public SampleDataSource()
        {
            dataCore = new SampleDataModel();
            String ITEM_CONTENT1 = String.Format("Item Content: {0}\n\n",
                        "帮助文档1");
            dataCore.CreateGroup("地图浏览功能",
                    "地图浏览功能",
                    "",
                    typeof(MainForm).Namespace + ".Assets.DarkGray.png",
                    "Group Description: 可以浏览地图");
            dataCore.AddItem(new SampleDataItem("放大、缩小",
                    "",//Item Subtitle
                    typeof(MainForm).Namespace + ".Assets.LightGray.png",
                    "描述:地图可以方法缩小",
                    ITEM_CONTENT1,
                    "地图浏览功能"));
            dataCore.AddItem(new SampleDataItem("平移",
                    "",
                    typeof(MainForm).Namespace + ".Assets.DarkGray.png",
                    "Item Description",
                    ITEM_CONTENT1,
                    "地图浏览功能"));

            String ITEM_CONTENT2 = String.Format("Item Content: {0}\n\n",
            "帮助文档2");
            dataCore.CreateGroup("查询功能",
                    "查询功能",
                    "Group Subtitle: 2",
                    typeof(MainForm).Namespace + ".Assets.LightGray.png",
                    "Group Description");
            dataCore.AddItem(new SampleDataItem("框选查询",
                    "", //Item Subtitle
                    typeof(MainForm).Namespace + ".Assets.DarkGray.png",
                    "Item Description",
                    ITEM_CONTENT2,
                    "查询功能"));
            dataCore.AddItem(new SampleDataItem("门店查询",
                    "",
                    typeof(MainForm).Namespace + ".Assets.MediumGray.png",
                    "Item Description",
                    ITEM_CONTENT2,
                    "查询功能"));

            String ITEM_CONTENT = String.Format("Item Content: {0}\n\n",
            "默认帮助文档");
            dataCore.CreateGroup("分析功能",
                    "分析功能",
                    "Group Subtitle: 3",
                    typeof(MainForm).Namespace + ".Assets.MediumGray.png",
                    "Group Description");
            dataCore.AddItem(new SampleDataItem("配送分析",
                    "",
                    typeof(MainForm).Namespace + ".Assets.MediumGray.png",
                    "Item Description",
                    ITEM_CONTENT,
                    "分析功能"));
            dataCore.AddItem(new SampleDataItem("服务范围分析",
                    "",
                    typeof(MainForm).Namespace + ".Assets.LightGray.png",
                    "Item Description",
                    ITEM_CONTENT,
                    "分析功能"));
            
            dataCore.CreateGroup("可视化功能",
                    "可视化功能",
                    "Group Subtitle: 4",
                    typeof(MainForm).Namespace + ".Assets.LightGray.png",
                    "Group Description");
            dataCore.AddItem(new SampleDataItem("热力图",
                    "",
                    typeof(MainForm).Namespace + ".Assets.DarkGray.png",
                    "Item Description",
                    ITEM_CONTENT,
                          "可视化功能"));
        

            dataCore.CreateGroup("算法优化分析功能",
                    "算法优化分析功能",
                    "Group Subtitle: 5",
                    typeof(MainForm).Namespace + ".Assets.MediumGray.png",
                    "Group Description");
            dataCore.AddItem(new SampleDataItem("蚁群算法",
                    "",
                    typeof(MainForm).Namespace + ".Assets.LightGray.png",
                    "Item Description",
                    ITEM_CONTENT,
                          "算法优化分析功能"));
            dataCore.AddItem(new SampleDataItem("粒子群算法",
                    "",
                    typeof(MainForm).Namespace + ".Assets.DarkGray.png",
                    "Item Description",
                    ITEM_CONTENT,
                          "算法优化分析功能"));

            dataCore.CreateGroup("其他功能",
                    "其他功能",
                    "Group Subtitle: 6",
                    typeof(MainForm).Namespace + ".Assets.DarkGray.png",
                    "Group Description");
            dataCore.AddItem(new SampleDataItem("其他",
                    "",
                    typeof(MainForm).Namespace + ".Assets.LightGray.png",
                    "Item Description",
                    ITEM_CONTENT,
                          "其他功能"));
        }
        public SampleDataModel Data { get { return dataCore; } }
    }
}
