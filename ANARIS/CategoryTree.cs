using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class CategoryTree : Form, ANS_View
    {

        private int categoryDepth = 1;
        bool userNodeSelection = false;
        List<TreeNode> nodeList = new List<TreeNode>();
        public DataBaseCategories tmpCategories = new DataBaseCategories();
        TreeNode selected = new TreeNode();
        int p = -1;
        int c = -1;

        ANS_Controller _controller;

        public CategoryTree()
        {
            InitializeComponent();
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }


        private void CategoryTree_Load(object sender, EventArgs e)
        {
            if (catTreeView.Nodes.Count != 0)
            {
                foreach (TreeNode node in catTreeView.Nodes)
                {
                    resetNodetext(node);
                }
            }
        }


        private void addNodeBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text))
            {
                if (catTreeView.SelectedNode == null)
                {
                    TreeNode newone = new TreeNode();
                    //newone.ForeColor = Color.Orange;
                    newone.NodeFont = new Font(catTreeView.Font, FontStyle.Bold);

                    newone.Name = "CAT_" + randomNameGenerator();
                    newone.Text = UppercaseFirst(nameBox.Text);
                    catTreeView.Nodes.Add(newone);
                    catTreeView.SelectedNode = newone;
                    resetNodetext(newone);
                    tmpCategories.List.Add(new Category());

                }
                else
                {
                    try
                    {
                        TreeNode selected = catTreeView.SelectedNode;
                        if (selected.Level < categoryDepth)
                        {
                            TreeNode newone = new TreeNode();
                            newone.Name = randomNameGenerator();
                            newone.Text = UppercaseFirst(nameBox.Text);
                            selected.Nodes.Add(newone);
                            selected.ExpandAll();
                            tmpCategories.List[selected.Index].subCategories.Add(new SubCategory());
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ups. Wystąpił błąd.");
                    }
                }
            }

            if (userNodeSelection) { }
            else { catTreeView.SelectedNode = null; }

        }

        private static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public void resetNodetext(TreeNode node)
        {
            node.Text = node.Text;
        }


        private void chngNameBtn_Click(object sender, EventArgs e)
        {
            if (catTreeView.SelectedNode != null && nameBox.Text != "")
            {
                catTreeView.SelectedNode.Text = nameBox.Text;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (catTreeView.SelectedNode != null)
            {
                catTreeView.SelectedNode.Remove();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            String msg = "";
            if (catTreeView.Nodes.Count > 0)
            {
                TreeNode[] RootNodeArray = new TreeNode[catTreeView.Nodes.Count];
                catTreeView.Nodes.CopyTo(RootNodeArray, 0);

                // Display the root nodes.
                foreach (TreeNode node in RootNodeArray)
                {
                    msg += node.Text + "\n";
                }
                MessageBox.Show(msg);

            }
        }


        private string randomNameGenerator()
        {
            Random rnd = new Random();
            int liczba;
            char znak;
            string nazwa = "";

            for (int i = 0; i <= 5; i++)
            {
                do { liczba = rnd.Next(48, 123); }
                while (liczba < 48 || (liczba > 57 && liczba < 65) || (liczba > 90 && liczba < 97) || liczba > 122);

                znak = (char)liczba;
                nazwa += znak;
            }

            foreach (TreeNode node in catTreeView.Nodes)
            {
                if (node.Nodes.Count != 0)
                {
                    foreach (TreeNode subnode in node.Nodes)
                    {
                        if (subnode.Name == nazwa) { nazwa = randomNameGenerator(); }
                    }
                }

                if (node.Name == nazwa) { nazwa = randomNameGenerator(); }
            }

            return nazwa;
        }

        private void catTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateDescription(p, c, tmpCategories, txtDescription.Text);
            if (catTreeView.HitTest(e.Location).Node == null)
            {
                catTreeView.SelectedNode = null;
                userNodeSelection = false;
                nameBox.Text = "";
                txtDescription.Text = "Opis kategorii";
                p = -1; c = -1;
            }
            else { userNodeSelection = true; }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            nodeList.Clear();
            foreach (TreeNode node in catTreeView.Nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    MessageBox.Show("Kategoria '" + node.Text + "' musi zawierać przynajmniej jedną podkategorię.");
                    break;
                }
                else
                {
                    TreeNode clonedNode = (TreeNode)node.Clone();
                    nodeList.Add(clonedNode);
                }
            }
            UpdateDescription(p, c, tmpCategories, txtDescription.Text);
            _controller.add_CategoryManager();
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            catTreeView.Nodes.Clear();

            foreach (TreeNode node in nodeList)
            {
                catTreeView.Nodes.Add(node);
                resetNodetext(node);
            }
            tmpCategories.Clone(_controller.dbCategories);

        }

        private void catTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            UpdateDescription(p, c, tmpCategories, txtDescription.Text);
            TreeNode node = e.Node as TreeNode;
            if (catTreeView.SelectedNode != null)
            {
                nameBox.Text = node.Text;
                if (node.Level == 0)
                {
                    p = node.Index;
                    c = -1;
                    txtDescription.Text = tmpCategories.List[node.Index].description;
                }
                else
                {
                    p = node.Parent.Index;
                    c = node.Index;
                    txtDescription.Text = tmpCategories.List[node.Parent.Index].subCategories[node.Index].description;
                }

            }

        }

        private static void UpdateDescription(int p, int c, DataBaseCategories tmpCategories, string txt)
        {
            if (p != -1 && c == -1)
            {
                tmpCategories.List[p].description = txt;
            }
            else if (p != -1 && c != -1)
            {
                tmpCategories.List[p].subCategories[c].description = txt;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _controller.ShowHideCategoryManager();
        }
    }
}


