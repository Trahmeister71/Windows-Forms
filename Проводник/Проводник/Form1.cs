using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проводник
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[] astrLogicalDrives = Directory.GetLogicalDrives();
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("Этот компьютер");
            foreach (string disk in astrLogicalDrives)
            {
                if (disk == "F:\\")
                    break;
                TreeNode diskNode = treeView1.Nodes[0].Nodes.Add(disk);
                string[] astrLogicalDIRECT = Directory.GetDirectories(disk);
                foreach (string dir in astrLogicalDIRECT)
                {
                    diskNode.Nodes.Add(dir);
                }
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Parent == null)
            {
                return;
            }
            treeView1.SelectedNode = treeView1.SelectedNode.Parent;
            treeView1.SelectedNode.Collapse();
        }
        int i = 1;
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            if (i == 1) { listView1.View = View.SmallIcon; i++; }
            else if (i == 2) { listView1.View = View.Tile; i++; }
            else if (i == 3) { listView1.View = View.List; i++; }
            else if (i == 4) { listView1.View = View.LargeIcon; i = 1; }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "Этот компьютер")
            {
                return;
            }
            listView1.Items.Clear();
            ImageList image_list1 = new ImageList(); // список изображений для хранения малых значков
            ImageList image_list2 = new ImageList(); // список изображений для хранения больших значков
            string pathToFolder = treeView1.SelectedNode.Text;

            image_list1.ColorDepth = ColorDepth.Depth32Bit;

            // установим размер изображения
            image_list1.ImageSize = new Size(16, 16);

            // ассоциируем список маленьких изображений с ListView
            listView1.SmallImageList = image_list1;

            // глубина цвета изображений
            image_list2.ColorDepth = ColorDepth.Depth32Bit;

            // установим размер изображения
            image_list2.ImageSize = new Size(32, 32);

            // ассоциируем список маленьких изображений с ListView
            listView1.LargeImageList = image_list2;

            string[] files = Directory.GetFiles(pathToFolder);
            string[] directories = Directory.GetDirectories(pathToFolder);
            Icon icon = new Icon(@"icon.ICO");
            image_list1.Images.Add(icon);
            image_list2.Images.Add(icon);
            foreach (string dir in directories)
            {
                listView1.Items.Add(dir, 0);
            }
            int index = 1;
            foreach (string file in files)
            {
                icon = Icon.ExtractAssociatedIcon(file);
                image_list1.Images.Add(icon);
                image_list2.Images.Add(icon);
                listView1.Items.Add(file, index++);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.GetNodeCount(false) == 0)
            {
                return;
            }
            treeView1.SelectedNode.ExpandAll();
            treeView1.SelectedNode = treeView1.SelectedNode.Nodes[0];
            treeView1.SelectedNode.Collapse();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Parent == null)
            {
                return;
            }
            if (treeView1.SelectedNode == treeView1.SelectedNode.FirstNode)
            {
                treeView1.SelectedNode = treeView1.SelectedNode.Parent;
                treeView1.SelectedNode.Collapse();

            }
            else
            {
                treeView1.SelectedNode = treeView1.SelectedNode.PrevNode;
                treeView1.SelectedNode.Collapse();
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
    }
}
