using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.SqlClient;

namespace MainModule
{
	/// <summary>
	/// PageFromServer の概要の説明です。
	/// </summary>
	public class PageDirClear : System.Windows.Forms.UserControl
	{
		public frmMain frmMain = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFrom;
		private System.Windows.Forms.Button btnFrom;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnClrAdd;
		private System.Windows.Forms.TextBox txtClr;
		private System.Windows.Forms.CheckedListBox clstClr;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button btnClrMod;
		private System.Windows.Forms.Button btnClrDel;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PageDirClear()
		{
			// この呼び出しは、Windows.Forms フォーム デザイナで必要です。
			InitializeComponent();
		}

		/// <summary>
		/// set by main form when load
		/// </summary>
		public void Init(Form frm)
		{
			frmMain = (frmMain)frm;
		}

		/// <summary>
		/// for main form to get Title
		/// </summary>
		public string Title
		{
			get
			{
				return "DirClear";
			}
		}

		/// <summary>
		/// for main form to get Title
		/// </summary>
		public string Comment
		{
			get
			{
				return "Clear project for you.";
			}
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region コンポーネント デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFrom = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClrAdd = new System.Windows.Forms.Button();
            this.txtClr = new System.Windows.Forms.TextBox();
            this.clstClr = new System.Windows.Forms.CheckedListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnClrMod = new System.Windows.Forms.Button();
            this.btnClrDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Location = new System.Drawing.Point(56, 8);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(479, 21);
            this.txtFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Dir:";
            // 
            // btnFrom
            // 
            this.btnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrom.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFrom.Location = new System.Drawing.Point(535, 8);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(16, 19);
            this.btnFrom.TabIndex = 11;
            this.btnFrom.Text = "...";
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(312, 48);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 13;
            this.btnRun.Text = "StartDel";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(384, 48);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClrAdd
            // 
            this.btnClrAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClrAdd.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.btnClrAdd.Location = new System.Drawing.Point(184, 141);
            this.btnClrAdd.Name = "btnClrAdd";
            this.btnClrAdd.Size = new System.Drawing.Size(40, 19);
            this.btnClrAdd.TabIndex = 43;
            this.btnClrAdd.Text = "Add";
            this.btnClrAdd.Click += new System.EventHandler(this.btnClrAdd_Click);
            // 
            // txtClr
            // 
            this.txtClr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClr.Location = new System.Drawing.Point(56, 141);
            this.txtClr.Name = "txtClr";
            this.txtClr.Size = new System.Drawing.Size(128, 21);
            this.txtClr.TabIndex = 42;
            // 
            // clstClr
            // 
            this.clstClr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clstClr.Items.AddRange(new object[] {
            "*.bak",
            "obj\\",
            "bin\\*.pdb",
            "bin\\Debug\\"});
            this.clstClr.Location = new System.Drawing.Point(56, 48);
            this.clstClr.Name = "clstClr";
            this.clstClr.Size = new System.Drawing.Size(248, 84);
            this.clstClr.TabIndex = 46;
            this.clstClr.SelectedIndexChanged += new System.EventHandler(this.clstClr_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(0, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 16);
            this.label21.TabIndex = 41;
            this.label21.Text = "Delete file list:";
            // 
            // btnClrMod
            // 
            this.btnClrMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClrMod.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.btnClrMod.Location = new System.Drawing.Point(224, 141);
            this.btnClrMod.Name = "btnClrMod";
            this.btnClrMod.Size = new System.Drawing.Size(40, 19);
            this.btnClrMod.TabIndex = 44;
            this.btnClrMod.Text = "Mod";
            this.btnClrMod.Click += new System.EventHandler(this.btnClrMod_Click);
            // 
            // btnClrDel
            // 
            this.btnClrDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClrDel.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.btnClrDel.Location = new System.Drawing.Point(264, 141);
            this.btnClrDel.Name = "btnClrDel";
            this.btnClrDel.Size = new System.Drawing.Size(40, 19);
            this.btnClrDel.TabIndex = 45;
            this.btnClrDel.Text = "Del";
            this.btnClrDel.Click += new System.EventHandler(this.btnClrDel_Click);
            // 
            // PageDirClear
            // 
            this.Controls.Add(this.btnClrAdd);
            this.Controls.Add(this.txtClr);
            this.Controls.Add(this.clstClr);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnClrMod);
            this.Controls.Add(this.btnClrDel);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnFrom);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Name = "PageDirClear";
            this.Size = new System.Drawing.Size(551, 163);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void Config_Load(System.Collections.Specialized.NameValueCollection coll)
		{
			cc.Util.setFormConfig(this, coll);
		}

		public void Config_Save(System.IO.StreamWriter sw)
		{
			sw.Write(cc.Util.getFormConfig(this));
		}

		private void btnFrom_Click(object sender, System.EventArgs e)
		{
			string sPath = cc.Util.DirSelect("Please Select Folder:", txtFrom.Text);
			if(sPath != null)
			{
				txtFrom.Text = sPath;
				if(!txtFrom.Text.EndsWith("\\"))
				{
					txtFrom.Text += "\\";
				}
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			if(btnExit.Text.Equals("Cancel"))
			{
				frmMain.isCanceling = true;
				btnExit.Text = "Cancel...";
			}
			if(btnExit.Text.Equals("Exit"))
			{
				frmMain.Close();
			}
		}

		private void btnClrAdd_Click(object sender, System.EventArgs e)
		{
			string sItem = txtClr.Text.Trim();
			if(!sItem.Equals(""))
			{
				for(int i = 0; i < clstClr.Items.Count; i++)
				{
					if(clstClr.Items[i].ToString().Equals(sItem))
					{
						frmMain.status.Text = "what you add is Exist in list";
						return;
					}
				}
				clstClr.Items.Add(sItem);
				clstClr.SetItemChecked(clstClr.Items.Count - 1, true);
			}
			else
			{
				frmMain.status.Text = "Please input what to add";
			}
		}

		private void btnClrMod_Click(object sender, System.EventArgs e)
		{
			frmMain.status.Text = "";
			string sItem = txtClr.Text.Trim();
			if(!sItem.Equals(""))
			{
				for(int i = 0; i < clstClr.Items.Count; i++)
				{
					if(clstClr.Items[i].ToString().Equals(sItem))
					{
						frmMain.status.Text = "what you add is Exist in list";
						return;
					}
				}
				if(clstClr.SelectedIndex >= 0)
				{
					clstClr.Items[clstClr.SelectedIndex] = sItem;
				}
				else
				{
					frmMain.status.Text = "Please select first!";
				}
			}
			else
			{
				frmMain.status.Text = "Please input what to modify";
			}
		}

		private void btnClrDel_Click(object sender, System.EventArgs e)
		{
			frmMain.status.Text = "";
			string sItem = txtClr.Text.Trim();
			if(!sItem.Equals(""))
			{
				for(int i = 0; i < clstClr.Items.Count; i++)
				{
					if(clstClr.Items[i].ToString().Equals(sItem))
					{
						clstClr.Items.Remove(sItem);
						return;
					}
				}
			}
			else
			{
				frmMain.status.Text = "Please input what to clear";
			}
		}

		private void clstClr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			frmMain.status.Text = "";
			if(clstClr.SelectedIndex >= 0)
			{
				txtClr.Text = clstClr.Items[clstClr.SelectedIndex].ToString();
			}
		}

		cc.Msg msg;
		//for calculate time
		DateTime MainTime = System.DateTime.Now;
		bool isMainStart = false;
		private void btnRun_Click(object sender, System.EventArgs e)
		{
			msg = frmMain.msg;
			if(frmMain.isCanceling || frmMain.isRunning)
			{
				frmMain.status.Text = "can not run this time";
				return;
			}

			frmMain.isRunning = true;
			btnRun.Enabled = false;
			btnExit.Text = "Cancel";
			msg.clear();

			try
			{
				run_main();
			}
			catch(cc.AppException exp)
			{
				if(!exp.isIgnore)
				{
					msg.println("have error:" + exp.MessageAll);
				}
			}
			catch(Exception exp)
			{
				msg.println("not expected error::" + exp.Message);
			}

			if(isMainStart)
			{
				//if output Start,then out "end time"
				msg.println("End:" + System.DateTime.Now + "(elapsed:" + (int)((System.DateTime.Now - MainTime).TotalMilliseconds/1000) + " Seconds)");
				isMainStart = false;
			}

			btnExit.Text = "Exit";
			frmMain.isRunning = false;
			frmMain.isCanceling = false;
			btnRun.Enabled = true;

			if(frmMain.isClosing)
			{
				frmMain.Close();
			}
		}
		private void run_main()
		{
			string sFrom = txtFrom.Text.Trim();
			if(sFrom.Equals(""))
			{
				msg.println("what dir to del?", Color.Red);
				return;
			}
			if(!sFrom.EndsWith("\\"))
			{
				sFrom += "\\";
			}
			if(!Directory.Exists(sFrom))
			{
				msg.println("not exist this dir", Color.Red);
				return;
			}
			if(clstClr.CheckedItems.Count < 1) 
			{
				msg.println("Please define or select file&directory to delete.");
				return;
			}

			//Start do samething
			if(MessageBox.Show("Start delete files defined in list?", "Msg...", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			msg.clear();
			msg.Focus();
			frmMain.status.Text = "delete files.";
			isMainStart = true;
			MainTime = System.DateTime.Now;
			msg.println("Start:" + MainTime);

			run_main_sub(sFrom);
		}
		//if return false,then jump out of loop
		private bool run_main_sub(string sDirName)
		{
			//if user want cancel?
			Application.DoEvents();
			if(frmMain.isClosing)
			{
				msg.println("Closing...");
				return false;
			}
			else if(frmMain.isCanceling)
			{
				if(MessageBox.Show("Cancel?", "Msg...", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
				{
					msg.println("User Cancel.");
					return false;
				}
				else
				{
					frmMain.isCanceling = false;
				}
			}

			if(!sDirName.EndsWith("\\"))
			{
				sDirName += "\\";
			}
			msg.println(sDirName);
			for(int j = 0; j < clstClr.CheckedItems.Count; j++)
			{
				string sDelName = clstClr.CheckedItems[j].ToString();
				if(sDelName.EndsWith("\\"))
				{
					if(Directory.Exists(sDirName + sDelName))
					{
						cc.Util.DirDeleteAll(sDirName + sDelName);
						if(Directory.Exists(sDirName + sDelName))
						{
							msg.println("  Cann't Del Dir:" + sDirName + sDelName + "\r\n");
						}
					}
				}
				else
				{
					if(Directory.Exists(Path.GetDirectoryName(sDirName + sDelName)))
					{
						string[] files = Directory.GetFiles(sDirName, sDelName);
						foreach(string element in files)
						{
							FileInfo fi = new FileInfo(element);
							if(fi.Attributes != FileAttributes.Normal)
							{
								fi.Attributes = FileAttributes.Normal;
							}
							File.Delete(element);
							if(File.Exists(element))
							{
								msg.println("  Cann't Del File:" + element + "\r\n");
							}
						}
					}
				}
			}
			foreach(string element in Directory.GetDirectories(sDirName))
			{
				if(!run_main_sub(element))
				{
					return false;
				}
			}
			return true;
		}

	}
}
