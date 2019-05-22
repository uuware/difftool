using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;
using System.Data.SqlClient;

namespace MainModule
{
	/// <summary>
	/// PageFromServer の概要の説明です。
	/// </summary>
	public class PageDirDiff : System.Windows.Forms.UserControl
	{
		public frmMain frmMain = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFrom;
		private System.Windows.Forms.TextBox txtTo;
		private System.Windows.Forms.Button btnFrom;
		private System.Windows.Forms.Button btnTo;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnClrAdd;
		private System.Windows.Forms.TextBox txtClr;
		private System.Windows.Forms.CheckedListBox clstClr;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Button btnClrMod;
		private System.Windows.Forms.Button btnClrDel;
		private System.Windows.Forms.Button btnCopyNew;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNew;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton radDate;
		private System.Windows.Forms.RadioButton radContent;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDiff;
		private System.Windows.Forms.Button btnDiff;
		private System.Windows.Forms.CheckBox chkDiffTo;
		private System.Windows.Forms.TextBox txtDiffTo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnDiffTo;
		private System.Windows.Forms.CheckBox chkSameToDiff;
		private System.Windows.Forms.CheckBox chkShowSkip;
		private System.Windows.Forms.CheckBox chkShowNotExist;
		private System.Windows.Forms.CheckBox chkShowSameOrOld;
		private System.Windows.Forms.CheckBox chkDiffNotExist;
		private System.Windows.Forms.CheckBox chkCopyNotExist;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PageDirDiff()
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
				return "DirDiff";
			}
		}

		/// <summary>
		/// for main form to get Title
		/// </summary>
		public string Comment
		{
			get
			{
				return "compared with dirferent dir.";
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
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFrom = new System.Windows.Forms.Button();
            this.btnTo = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClrAdd = new System.Windows.Forms.Button();
            this.txtClr = new System.Windows.Forms.TextBox();
            this.clstClr = new System.Windows.Forms.CheckedListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnClrMod = new System.Windows.Forms.Button();
            this.btnClrDel = new System.Windows.Forms.Button();
            this.btnCopyNew = new System.Windows.Forms.Button();
            this.chkShowNotExist = new System.Windows.Forms.CheckBox();
            this.chkShowSkip = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.chkSameToDiff = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radDate = new System.Windows.Forms.RadioButton();
            this.radContent = new System.Windows.Forms.RadioButton();
            this.txtDiff = new System.Windows.Forms.TextBox();
            this.btnDiff = new System.Windows.Forms.Button();
            this.chkDiffTo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiffTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDiffTo = new System.Windows.Forms.Button();
            this.chkDiffNotExist = new System.Windows.Forms.CheckBox();
            this.chkCopyNotExist = new System.Windows.Forms.CheckBox();
            this.chkShowSameOrOld = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Location = new System.Drawing.Point(56, 8);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(668, 21);
            this.txtFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dir From:";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.Location = new System.Drawing.Point(56, 32);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(668, 21);
            this.txtTo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diff To:";
            // 
            // btnFrom
            // 
            this.btnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrom.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFrom.Location = new System.Drawing.Point(724, 8);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(16, 19);
            this.btnFrom.TabIndex = 11;
            this.btnFrom.Text = "...";
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // btnTo
            // 
            this.btnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTo.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTo.Location = new System.Drawing.Point(724, 32);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(16, 19);
            this.btnTo.TabIndex = 11;
            this.btnTo.Text = "...";
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(328, 80);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(72, 23);
            this.btnRun.TabIndex = 13;
            this.btnRun.Text = "StartDiff";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(480, 80);
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
            this.btnClrAdd.Location = new System.Drawing.Point(184, 277);
            this.btnClrAdd.Name = "btnClrAdd";
            this.btnClrAdd.Size = new System.Drawing.Size(40, 21);
            this.btnClrAdd.TabIndex = 49;
            this.btnClrAdd.Text = "Add";
            this.btnClrAdd.Click += new System.EventHandler(this.btnClrAdd_Click);
            // 
            // txtClr
            // 
            this.txtClr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtClr.Location = new System.Drawing.Point(56, 277);
            this.txtClr.Name = "txtClr";
            this.txtClr.Size = new System.Drawing.Size(128, 21);
            this.txtClr.TabIndex = 48;
            // 
            // clstClr
            // 
            this.clstClr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clstClr.Items.AddRange(new object[] {
            "*.bak",
            ".svn\\"});
            this.clstClr.Location = new System.Drawing.Point(56, 112);
            this.clstClr.Name = "clstClr";
            this.clstClr.Size = new System.Drawing.Size(248, 164);
            this.clstClr.TabIndex = 52;
            this.clstClr.SelectedIndexChanged += new System.EventHandler(this.clstClr_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(0, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(304, 13);
            this.label21.TabIndex = 47;
            this.label21.Text = "skip list: (do not copy or diff this dirs&&files)";
            // 
            // btnClrMod
            // 
            this.btnClrMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClrMod.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.btnClrMod.Location = new System.Drawing.Point(224, 277);
            this.btnClrMod.Name = "btnClrMod";
            this.btnClrMod.Size = new System.Drawing.Size(40, 21);
            this.btnClrMod.TabIndex = 50;
            this.btnClrMod.Text = "Mod";
            this.btnClrMod.Click += new System.EventHandler(this.btnClrMod_Click);
            // 
            // btnClrDel
            // 
            this.btnClrDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClrDel.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.btnClrDel.Location = new System.Drawing.Point(264, 277);
            this.btnClrDel.Name = "btnClrDel";
            this.btnClrDel.Size = new System.Drawing.Size(40, 21);
            this.btnClrDel.TabIndex = 51;
            this.btnClrDel.Text = "Del";
            this.btnClrDel.Click += new System.EventHandler(this.btnClrDel_Click);
            // 
            // btnCopyNew
            // 
            this.btnCopyNew.Location = new System.Drawing.Point(400, 80);
            this.btnCopyNew.Name = "btnCopyNew";
            this.btnCopyNew.Size = new System.Drawing.Size(80, 23);
            this.btnCopyNew.TabIndex = 13;
            this.btnCopyNew.Text = "CopyNewFile";
            this.btnCopyNew.Click += new System.EventHandler(this.btnCopyNew_Click);
            // 
            // chkShowNotExist
            // 
            this.chkShowNotExist.Location = new System.Drawing.Point(313, 112);
            this.chkShowNotExist.Name = "chkShowNotExist";
            this.chkShowNotExist.Size = new System.Drawing.Size(243, 20);
            this.chkShowNotExist.TabIndex = 53;
            this.chkShowNotExist.Text = "logging not existed files&&dirs";
            // 
            // chkShowSkip
            // 
            this.chkShowSkip.Location = new System.Drawing.Point(313, 150);
            this.chkShowSkip.Name = "chkShowSkip";
            this.chkShowSkip.Size = new System.Drawing.Size(243, 20);
            this.chkShowSkip.TabIndex = 53;
            this.chkShowSkip.Text = "logging files even in skip list";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNew.Location = new System.Drawing.Point(724, 56);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(16, 19);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "...";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Copy To:";
            // 
            // txtNew
            // 
            this.txtNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNew.Location = new System.Drawing.Point(56, 56);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(528, 21);
            this.txtNew.TabIndex = 0;
            // 
            // chkSameToDiff
            // 
            this.chkSameToDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSameToDiff.Location = new System.Drawing.Point(588, 56);
            this.chkSameToDiff.Name = "chkSameToDiff";
            this.chkSameToDiff.Size = new System.Drawing.Size(133, 24);
            this.chkSameToDiff.TabIndex = 54;
            this.chkSameToDiff.Text = "Same to \"Diff To\"";
            this.chkSameToDiff.CheckedChanged += new System.EventHandler(this.chkSameToDiff_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Depend on:";
            // 
            // radDate
            // 
            this.radDate.Checked = true;
            this.radDate.Location = new System.Drawing.Point(70, 74);
            this.radDate.Name = "radDate";
            this.radDate.Size = new System.Drawing.Size(144, 24);
            this.radDate.TabIndex = 55;
            this.radDate.TabStop = true;
            this.radDate.Text = "File LastWriteTime";
            // 
            // radContent
            // 
            this.radContent.Location = new System.Drawing.Point(220, 74);
            this.radContent.Name = "radContent";
            this.radContent.Size = new System.Drawing.Size(105, 24);
            this.radContent.TabIndex = 55;
            this.radContent.Text = "File Content";
            // 
            // txtDiff
            // 
            this.txtDiff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiff.Location = new System.Drawing.Point(312, 212);
            this.txtDiff.Name = "txtDiff";
            this.txtDiff.Size = new System.Drawing.Size(404, 21);
            this.txtDiff.TabIndex = 0;
            this.txtDiff.Text = ".\\diff.exe";
            // 
            // btnDiff
            // 
            this.btnDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiff.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDiff.Location = new System.Drawing.Point(716, 212);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(16, 19);
            this.btnDiff.TabIndex = 11;
            this.btnDiff.Text = "...";
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // chkDiffTo
            // 
            this.chkDiffTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDiffTo.Location = new System.Drawing.Point(700, 252);
            this.chkDiffTo.Name = "chkDiffTo";
            this.chkDiffTo.Size = new System.Drawing.Size(16, 24);
            this.chkDiffTo.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(312, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Diff.exe: (only need for \"File Content\")";
            // 
            // txtDiffTo
            // 
            this.txtDiffTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiffTo.Location = new System.Drawing.Point(312, 252);
            this.txtDiffTo.Name = "txtDiffTo";
            this.txtDiffTo.Size = new System.Drawing.Size(388, 21);
            this.txtDiffTo.TabIndex = 0;
            this.txtDiffTo.Text = "c:\\temp\\diff";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(312, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(382, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "save diff result to: (if not check-on, then shows log only)";
            // 
            // btnDiffTo
            // 
            this.btnDiffTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiffTo.Font = new System.Drawing.Font("MS UI Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDiffTo.Location = new System.Drawing.Point(716, 252);
            this.btnDiffTo.Name = "btnDiffTo";
            this.btnDiffTo.Size = new System.Drawing.Size(16, 19);
            this.btnDiffTo.TabIndex = 11;
            this.btnDiffTo.Text = "...";
            this.btnDiffTo.Click += new System.EventHandler(this.btnDiffTo_Click);
            // 
            // chkDiffNotExist
            // 
            this.chkDiffNotExist.Location = new System.Drawing.Point(312, 276);
            this.chkDiffNotExist.Name = "chkDiffNotExist";
            this.chkDiffNotExist.Size = new System.Drawing.Size(428, 21);
            this.chkDiffNotExist.TabIndex = 54;
            this.chkDiffNotExist.Text = "StartDiff:when files not existed at \"Diff To\",create \"XXX.new.diff\"";
            // 
            // chkCopyNotExist
            // 
            this.chkCopyNotExist.Checked = true;
            this.chkCopyNotExist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyNotExist.Location = new System.Drawing.Point(313, 172);
            this.chkCopyNotExist.Name = "chkCopyNotExist";
            this.chkCopyNotExist.Size = new System.Drawing.Size(370, 20);
            this.chkCopyNotExist.TabIndex = 54;
            this.chkCopyNotExist.Text = "CopyNewFile:when files not existed at \"Diff To\",copy it";
            // 
            // chkShowSameOrOld
            // 
            this.chkShowSameOrOld.Location = new System.Drawing.Point(313, 132);
            this.chkShowSameOrOld.Name = "chkShowSameOrOld";
            this.chkShowSameOrOld.Size = new System.Drawing.Size(294, 20);
            this.chkShowSameOrOld.TabIndex = 53;
            this.chkShowSameOrOld.Text = "logging same or old files";
            // 
            // PageDirDiff
            // 
            this.Controls.Add(this.btnDiff);
            this.Controls.Add(this.txtDiff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkShowNotExist);
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
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCopyNew);
            this.Controls.Add(this.chkShowSkip);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radContent);
            this.Controls.Add(this.chkDiffTo);
            this.Controls.Add(this.txtDiffTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDiffTo);
            this.Controls.Add(this.chkDiffNotExist);
            this.Controls.Add(this.chkCopyNotExist);
            this.Controls.Add(this.chkSameToDiff);
            this.Controls.Add(this.chkShowSameOrOld);
            this.Name = "PageDirDiff";
            this.Size = new System.Drawing.Size(740, 301);
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

		private void btnTo_Click(object sender, System.EventArgs e)
		{
			string sPath = cc.Util.DirSelect("Please Select Folder:", txtTo.Text);
			if(sPath != null)
			{
				txtTo.Text = sPath;
				if(!txtTo.Text.EndsWith("\\"))
				{
					txtTo.Text += "\\";
				}
			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			string sPath = cc.Util.DirSelect("Please Select Folder:", txtNew.Text);
			if(sPath != null)
			{
				txtNew.Text = sPath;
				if(!txtNew.Text.EndsWith("\\"))
				{
					txtNew.Text += "\\";
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

		//save this files&dir that not need treated
		System.Collections.Specialized.NameValueCollection collSkipDirFile
			= new System.Collections.Specialized.NameValueCollection();
		string sBaseDir = "";
		string sLastDir = "";
		bool isOutDiffFile = false;
		public string CutBaseDir(string sDir)
		{
			if(sDir.StartsWith(sBaseDir))
			{
				string sDirT = sDir.Substring(sBaseDir.Length);
				if(sDirT.EndsWith("\\"))
				{
					sLastDir = sDirT;
					return sDirT;
				}
				else
				{
					string sDirT2 = sDirT.Substring(0, sDirT.LastIndexOf("\\") + 1);
					if(!sDirT2.Equals(sLastDir))
					{
						sLastDir = sDirT2;
						msg.println(sDirT2);
					}
					sDirT = sDirT.Substring(sLastDir.Length);
					if(!sLastDir.Equals(""))
					{
						sDirT = "   " + sDirT;
					}
					return sDirT;
				}
			}
			else
			{
				return sDir;
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
			btnCopyNew.Enabled = false;
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
				msg.println("not expected error:" + exp.Message);
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
			btnCopyNew.Enabled = true;
			frmMain.status.Text = "";

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
				msg.println("need dir from", Color.Red);
				return;
			}
			if(!sFrom.EndsWith("\\"))
			{
				sFrom += "\\";
			}
			if(!Directory.Exists(sFrom))
			{
				msg.println("not exist dir from", Color.Red);
				return;
			}
			string sTo = txtTo.Text.Trim();
			if(sTo.Equals(""))
			{
				msg.println("need dir to", Color.Red);
				return;
			}
			if(!sTo.EndsWith("\\"))
			{
				sTo += "\\";
			}

			//Start do samething
			if(MessageBox.Show("Start diff Dir?", "Msg...", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			msg.clear();
			msg.Focus();
			frmMain.status.Text = "copy tables.";
			isMainStart = true;
			MainTime = System.DateTime.Now;
			msg.println("Start:" + MainTime);

			sBaseDir = sFrom;
			isOutDiffFile = true;
			collSkipDirFile.Clear();
			msg.println("-------------------- base on:" + sFrom);
			if(DirDiff(sFrom, sTo))
			{
				if(chkShowNotExist.Checked)
				{
					sBaseDir = sTo;
					collSkipDirFile.Clear();
					msg.println("");
					msg.println("(show msg only)search files that exist at \"Diff To\" but not exist \"Dir From\"" + sTo);
					msg.println("-------------------- base on:" + sTo);
					isOutDiffFile = false;
					DirDiff(sTo, sFrom);
				}

				//tree /F > list.txt
				string sDiffTo = txtDiffTo.Text.Trim();
				if(chkDiffTo.Checked && !sDiffTo.Equals(""))
				{
					if(!sDiffTo.EndsWith("\\"))
					{
						sDiffTo += "\\";
					}
					System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
					psi.UseShellExecute = false;
					psi.CreateNoWindow = true;
					psi.RedirectStandardOutput = true;
					psi.WorkingDirectory = sDiffTo;
					psi.FileName = "tree.com";
					psi.Arguments = "/F";
					try
					{
						msg.println("create list.txt file.");
						System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi);
						process.WaitForExit(1000 * 120);
						cc.Util.writeFile(sDiffTo + "diff_list.txt", process.StandardOutput.ReadToEnd());
					}
					catch(Exception exp)
					{
						msg.println(exp.Message, Color.Red);
						return;
					}
				}
			}
		}
		/// <summary>
		/// Diff directory structure recursively(new file only)
		/// </summary>
		public bool DirDiff(string src, string dst)
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

			if(src[src.Length-1] != Path.DirectorySeparatorChar)
			{
				src += Path.DirectorySeparatorChar;
			}
			if(dst[dst.Length-1] != Path.DirectorySeparatorChar)
			{
				dst += Path.DirectorySeparatorChar;
			}
			if(!Directory.Exists(dst))
			{
				//even dir is not exist,continue show not exist files
				if(chkShowNotExist.Checked)
				{
					msg.print(CutBaseDir(src));
					msg.println(" not exist in dest", Color.DeepPink);
				}
			}

			//add this file in list is not need treated
			for(int j = 0; j < clstClr.CheckedItems.Count; j++)
			{
				string sDelName = clstClr.CheckedItems[j].ToString();
				if(sDelName.EndsWith("\\"))
				{
					if(Directory.Exists(src + sDelName))
					{
						collSkipDirFile.Add(src + sDelName, "");
					}
				}
				else
				{
					if(Directory.Exists(Path.GetDirectoryName(src + sDelName)))
					{
						string[] files = Directory.GetFiles(src, sDelName);
						foreach(string element in files)
						{
							collSkipDirFile.Add(element, "");
						}
					}
				}
			}

			string[] dfiles = Directory.GetFiles(src);
			foreach(string element in dfiles)
			{
				//files in directory
				if(collSkipDirFile[element] != null)
				{
					if(chkShowSkip.Checked)
					{
						msg.print(CutBaseDir(element));
						msg.println(" in skip list", Color.Gray);
					}
				}
				else
				{
					string dstfile = dst + Path.GetFileName(element);
					if(!File.Exists(dstfile))
					{
						if(chkShowNotExist.Checked)
						{
							msg.print(CutBaseDir(element));
							msg.println(" not exist in dest", Color.DeepPink);
						}

						string sTo = txtTo.Text.Trim();
						string output = "new:" + element + "\r\n";
						string sDiffTo = txtDiffTo.Text.Trim();
						//is out DiffFile and is diff on Content and has sDiffTo
						if(isOutDiffFile && radContent.Checked && !sDiffTo.Equals("") && chkDiffTo.Checked && chkDiffNotExist.Checked)
						{
							if(!sDiffTo.EndsWith("\\"))
							{
								sDiffTo += "\\";
							}
							sDiffTo += dstfile.Substring(sTo.Length) + ".new.diff";
							if(!Directory.Exists(Path.GetDirectoryName(sDiffTo)))
							{
								Directory.CreateDirectory(Path.GetDirectoryName(sDiffTo));
							}
							cc.Util.writeFile(sDiffTo, output);
						}
					}
					else
					{
						//judge for newly
						if(radDate.Checked)
						{
							//depend on file time
							DateTime dt1 = File.GetLastWriteTime(element);
							DateTime dt2 = File.GetLastWriteTime(dstfile);
							if((dt1 - dt2).TotalMilliseconds > 0)
							{
								msg.print(CutBaseDir(element));
								msg.println(" newly[" + dt1.ToString("yyyy/mm/dd HH:MM:ss") + "]", Color.HotPink);
							}
							else if((dt1 - dt2).TotalMilliseconds == 0)
							{
								if(chkShowSameOrOld.Checked)
								{
									msg.print(CutBaseDir(element));
									msg.println(" same to dest", Color.Gray);
								}
							}
							else
							{
								if(chkShowSameOrOld.Checked)
								{
									msg.print(CutBaseDir(element));
									msg.println(" old then dest", Color.ForestGreen);
								}
							}
						}
						else
						{
							//depend on file content
							if(FileCompare(element, dstfile))
							{
								//same file
								if(chkShowSameOrOld.Checked)
								{
									msg.print(CutBaseDir(element));
									msg.println(" same content to dest", Color.Gray);
								}
							}
							else
							{
								//not same,new file
								msg.print(CutBaseDir(element));
								msg.println(" changed content to dest", Color.Crimson);
								//diff element dstfile > newdir
								if(isOutDiffFile && chkDiffTo.Checked)
								{
									DiffOut(element, dstfile);
								}
							}
						}
					}
				}
			}
			string[] dirs = Directory.GetDirectories(src);
			foreach(string element in dirs)
			{
				//Sub directories
				if(collSkipDirFile[element + "\\"] != null)
				{
					if(chkShowSkip.Checked)
					{
						msg.print(CutBaseDir(element + "\\"));
						msg.println(" in skip list", Color.Gray);
					}
				}
				else
				{
					if(!DirDiff(element, dst + Path.GetFileName(element)))
					{
						return false;
					}
				}
			}
			return true;
		}

		private void btnCopyNew_Click(object sender, System.EventArgs e)
		{
			msg = frmMain.msg;
			if(frmMain.isCanceling || frmMain.isRunning)
			{
				frmMain.status.Text = "can not run this time";
				return;
			}

			frmMain.isRunning = true;
			btnRun.Enabled = false;
			btnCopyNew.Enabled = false;
			btnExit.Text = "Cancel";
			msg.clear();

			try
			{
				copynew_main();
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
				msg.println("not expected error:" + exp.Message);
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
			btnCopyNew.Enabled = true;
			frmMain.status.Text = "";

			if(frmMain.isClosing)
			{
				frmMain.Close();
			}
		}
		private void copynew_main()
		{
			string sFrom = txtFrom.Text.Trim();
			if(sFrom.Equals(""))
			{
				msg.println("need dir from", Color.Red);
				return;
			}
			if(!sFrom.EndsWith("\\"))
			{
				sFrom += "\\";
			}
			if(!Directory.Exists(sFrom))
			{
				msg.println("not exist dir from", Color.Red);
				return;
			}
			string sTo = txtTo.Text.Trim();
			if(sTo.Equals(""))
			{
				msg.println("need dir \"Diff To\"", Color.Red);
				return;
			}
			if(!sTo.EndsWith("\\"))
			{
				sTo += "\\";
			}
			if(!chkSameToDiff.Checked && !Directory.Exists(sTo))
			{
				msg.println("not exist \"Diff To\"", Color.Red);
				return;
			}

			//newly
			string sNew = txtNew.Text.Trim();
			if(chkSameToDiff.Checked)
			{
				sNew = sTo;
			}
			else
			{
				if(sNew.Equals(""))
				{
					msg.println("need dir newly", Color.Red);
					return;
				}
				if(!sNew.EndsWith("\\"))
				{
					sNew += "\\";
				}
			}
			if(!Directory.Exists(sNew))
			{
				Directory.CreateDirectory(sNew);
			}
			if(!Directory.Exists(sNew))
			{
				msg.println("can not create dir \"Copy To\"", Color.Red);
				return;
			}

			//Start do samething
			if(MessageBox.Show("Start copy new files?", "Msg...", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			msg.clear();
			msg.Focus();
			frmMain.status.Text = "copy new files.";
			isMainStart = true;
			MainTime = System.DateTime.Now;
			msg.println("Start:" + MainTime);

			collSkipDirFile.Clear();
			sBaseDir = sFrom;
			DirCopyNew(sFrom, sTo, sNew);
		}
		/// <summary>
		/// Copy directory structure recursively(new file only)
		/// </summary>
		public bool DirCopyNew(string src, string dst, string sNew)
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

			if(src[src.Length - 1] != Path.DirectorySeparatorChar)
			{
				src += Path.DirectorySeparatorChar;
			}
			if(dst[dst.Length - 1] != Path.DirectorySeparatorChar)
			{
				dst += Path.DirectorySeparatorChar;
			}
			if(sNew[sNew.Length - 1] != Path.DirectorySeparatorChar)
			{
				sNew += Path.DirectorySeparatorChar;
			}

			//add this file in list is not need treated
			for(int j = 0; j < clstClr.CheckedItems.Count; j++)
			{
				string sDelName = clstClr.CheckedItems[j].ToString();
				if(sDelName.EndsWith("\\"))
				{
					if(Directory.Exists(src + sDelName))
					{
						collSkipDirFile.Add(src + sDelName, "");
					}
				}
				else
				{
					if(Directory.Exists(Path.GetDirectoryName(src + sDelName)))
					{
						string[] files = Directory.GetFiles(src, sDelName);
						foreach(string element in files)
						{
							collSkipDirFile.Add(element, "");
						}
					}
				}
			}

			string[] dfiles = Directory.GetFiles(src);
			foreach(string element in dfiles)
			{
				//files in directory
				if(collSkipDirFile[element] != null)
				{
					if(chkShowSkip.Checked)
					{
						msg.print(CutBaseDir(element + "\\"));
						msg.println(" in skip list", Color.Gray);
					}
				}
				else
				{
					string dstfile = dst + Path.GetFileName(element);
					if(!File.Exists(dstfile))
					{
						if(chkCopyNotExist.Checked)
						{
							if(!Directory.Exists(sNew))
							{
								Directory.CreateDirectory(sNew);
							}
							string dstfilenew = sNew + Path.GetFileName(element);
							if(File.Exists(dstfilenew))
							{
								FileInfo fi = new FileInfo(dstfilenew);
								if(fi.Attributes != FileAttributes.Normal)
								{
									fi.Attributes = FileAttributes.Normal;
								}
								File.Delete(dstfilenew);
							}
							File.Copy(element, dstfilenew, true);
							msg.print(CutBaseDir(element + "\\"));
							msg.println(" copy to \"Copy To\" for not exist", Color.DeepPink);
						}
						else
						{
							if(chkShowNotExist.Checked)
							{
								msg.print(CutBaseDir(element + "\\"));
								msg.println(" not exist,but not copy it", Color.DeepPink);
							}
						}
					}
					else
					{
						//judge for newly
						if(radDate.Checked)
						{
							//depend on file time
							DateTime dt1 = File.GetLastWriteTime(element);
							DateTime dt2 = File.GetLastWriteTime(dstfile);
							if((dt1 - dt2).TotalMilliseconds > 0)
							{
								if(!Directory.Exists(sNew))
								{
									Directory.CreateDirectory(sNew);
								}
								string dstfilenew = sNew + Path.GetFileName(element);
								if(File.Exists(dstfilenew))
								{
									FileInfo fi = new FileInfo(dstfilenew);
									if(fi.Attributes != FileAttributes.Normal)
									{
										fi.Attributes = FileAttributes.Normal;
									}
									File.Delete(dstfilenew);
								}
								File.Copy(element, dstfilenew, true);
								msg.print(CutBaseDir(element));
								msg.println(" copy to \"Copy To\" for newly[" + dt1.ToString("yyyy/mm/dd HH:MM:ss") + "]", Color.HotPink);
							}
							else
							{
								if(chkShowSameOrOld.Checked)
								{
									msg.print(CutBaseDir(element));
									msg.println(" skip for same or old", Color.Gray);
								}
							}
						}
						else
						{
							//depend on file content
							if(FileCompare(element, dstfile))
							{
								//same file
								if(chkShowSameOrOld.Checked)
								{
									msg.print(CutBaseDir(element));
									msg.println(" skip for same content", Color.Gray);
								}
							}
							else
							{
								//not same,new file
								if(!Directory.Exists(sNew))
								{
									Directory.CreateDirectory(sNew);
								}
								string dstfilenew = sNew + Path.GetFileName(element);
								if(File.Exists(dstfilenew))
								{
									FileInfo fi = new FileInfo(dstfilenew);
									if(fi.Attributes != FileAttributes.Normal)
									{
										fi.Attributes = FileAttributes.Normal;
									}
									File.Delete(dstfilenew);
								}
								File.Copy(element, dstfilenew, true);
								msg.print(CutBaseDir(element));
								msg.println(" copy to \"Copy To\" for new content", Color.Crimson);
							}
						}
					}
				}
			}
			string[] dirs = Directory.GetDirectories(src);
			foreach(string element in dirs)
			{
				//Sub directories
				if(collSkipDirFile[element + "\\"] != null)
				{
					if(chkShowSkip.Checked)
					{
						msg.print(CutBaseDir(element + "\\"));
						msg.println(" in skip list", Color.Gray);
					}
				}
				else
				{
					string sNewPath = sNew + Path.GetFileName(element);
					if(!DirCopyNew(element, dst + Path.GetFileName(element), sNewPath))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool FileCompare(string file1, string file2)
		{
			//depend on file content
			frmMain.status.Text = "Compare File:" + Path.GetFileName(file1);
			FileInfo fi1 = new FileInfo(file1);
			FileInfo fi2 = new FileInfo(file2);
			if(!fi1.Exists || !fi2.Exists || fi1.Length != fi2.Length)
			{
				return false;
			}
			StreamReader sr1 = new StreamReader(file1);
			StreamReader sr2 = new StreamReader(file2);
			int read1 = sr1.Read();
			int read2 = sr2.Read();
			while(read1 != -1 && read2 != -1 && read1 == read2)
			{
				read1 = sr1.Read();
				read2 = sr2.Read();
			}
			sr1.Close();
			sr2.Close();
			return (read1 == read2);
		}

		public bool DiffOut(string src, string des)
		{
			string sDiffPath = txtDiff.Text.Trim();
			if(sDiffPath.StartsWith(".\\"))
			{
				sDiffPath = Path.GetDirectoryName(Application.ExecutablePath) + sDiffPath.Substring(1);
			}
			if(File.Exists(sDiffPath) && File.Exists(src) && File.Exists(des))
			{
				System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
				psi.UseShellExecute = false;
				psi.CreateNoWindow = true;
				psi.RedirectStandardOutput = true;
				psi.FileName = sDiffPath;
				psi.Arguments = "\"" + src + "\" \"" + des + "\"";

				//psi.FileName = sDiffPath;
				//psi.Arguments = "\"" + src + "\" \"" + des + "\"";
				//psi.UseShellExecute = false;
				//psi.RedirectStandardOutput = true;
				//psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				try
				{
					//string sFrom = txtFrom.Text.Trim();
					string sTo = txtTo.Text.Trim();
					//string output = "diff \"" + src.Substring(sFrom.Length) + "\" \"" + des.Substring(sTo.Length) + "\"\r\n\r\n";
					string output = "diff \"" + src + "\" \"" + des + "\"\r\n\r\n";
					System.Diagnostics.Process process = System.Diagnostics.Process.Start(psi);
					output += process.StandardOutput.ReadToEnd();
					process.WaitForExit(30000);
					string sDiffTo = txtDiffTo.Text.Trim();
					if(!sDiffTo.Equals(""))
					{
						if(!sDiffTo.EndsWith("\\"))
						{
							sDiffTo += "\\";
						}
						sDiffTo += des.Substring(sTo.Length) + ".diff";
						if(!Directory.Exists(Path.GetDirectoryName(sDiffTo)))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(sDiffTo));
						}
						cc.Util.writeFile(sDiffTo, output);
					}
				}
				catch
				{
					return false;
				}
				return true;
			}
			return false;
		}

		private void btnDiff_Click(object sender, System.EventArgs e)
		{
			frmMain.status.Text = "";
			string initpath = Path.GetDirectoryName(Application.ExecutablePath);
			string sfilename = txtDiff.Text.Trim();
			if(sfilename.StartsWith(".\\"))
			{
				sfilename = initpath + sfilename.Substring(1);
			}
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			if(File.Exists(sfilename))
			{
				openFileDialog1.InitialDirectory = Path.GetFullPath(sfilename);
			}
			else
			{
				openFileDialog1.InitialDirectory = initpath;
			}
			openFileDialog1.Filter = "Diff exe file(*.exe; *.com)|*.exe; *.com;";
			openFileDialog1.Title = "Select Diff.exe file";

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if(Path.GetDirectoryName(openFileDialog1.FileName).StartsWith(initpath))
				{
					txtDiff.Text = openFileDialog1.FileName.Substring(initpath.Length);
					if(txtDiff.Text.StartsWith("\\"))
					{
						txtDiff.Text = "." + txtDiff.Text;
					}
				}
				else
				{
					txtDiff.Text = openFileDialog1.FileName;
				}
			}
		}

		private void btnDiffTo_Click(object sender, System.EventArgs e)
		{
			string sPath = cc.Util.DirSelect("Please Select Folder:", txtDiffTo.Text);
			if(sPath != null)
			{
				txtDiffTo.Text = sPath;
				if(!txtDiffTo.Text.EndsWith("\\"))
				{
					txtDiffTo.Text += "\\";
				}
			}
		}

		private void chkSameToDiff_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkSameToDiff.Checked)
			{
				this.txtNew.Font = new Font("MS UI Gothic", 9, FontStyle.Strikeout);
			}
			else
			{
				this.txtNew.Font = new Font("MS UI Gothic", 9);
			}
			this.txtNew.Enabled = !chkSameToDiff.Checked;
			this.btnNew.Enabled = !chkSameToDiff.Checked;
		}

	}
}
