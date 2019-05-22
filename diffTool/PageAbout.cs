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
	public class PageAbout : System.Windows.Forms.UserControl
	{
		public frmMain frmMain = null;
		private System.Windows.Forms.ListBox lstPage;
		private System.Windows.Forms.TextBox txtShortKey;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnShortKey;
		private System.Windows.Forms.Button btnIniLoad;
		private System.Windows.Forms.Button btnIniSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnPageHide;
		private System.Windows.Forms.Button btnPageShow;
		private System.Windows.Forms.Label label2;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PageAbout()
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
				return "About";
			}
		}

		/// <summary>
		/// for main form to get Title
		/// </summary>
		public string Comment
		{
			get
			{
				return "Save or Load Config,Show or Hide Pages.";
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
			this.lstPage = new System.Windows.Forms.ListBox();
			this.txtShortKey = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnShortKey = new System.Windows.Forms.Button();
			this.btnIniLoad = new System.Windows.Forms.Button();
			this.btnIniSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnPageHide = new System.Windows.Forms.Button();
			this.btnPageShow = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lstPage
			// 
			this.lstPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.lstPage.ItemHeight = 12;
			this.lstPage.Location = new System.Drawing.Point(0, 48);
			this.lstPage.Name = "lstPage";
			this.lstPage.Size = new System.Drawing.Size(256, 136);
			this.lstPage.TabIndex = 54;
			// 
			// txtShortKey
			// 
			this.txtShortKey.BackColor = System.Drawing.SystemColors.Info;
			this.txtShortKey.Enabled = false;
			this.txtShortKey.Location = new System.Drawing.Point(264, 96);
			this.txtShortKey.Name = "txtShortKey";
			this.txtShortKey.ReadOnly = true;
			this.txtShortKey.Size = new System.Drawing.Size(168, 19);
			this.txtShortKey.TabIndex = 53;
			this.txtShortKey.Text = "D1(49) + Control";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(264, 80);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(184, 16);
			this.label9.TabIndex = 52;
			this.label9.Text = "Key for Hide/Show this window:";
			// 
			// btnShortKey
			// 
			this.btnShortKey.Location = new System.Drawing.Point(432, 96);
			this.btnShortKey.Name = "btnShortKey";
			this.btnShortKey.Size = new System.Drawing.Size(64, 19);
			this.btnShortKey.TabIndex = 50;
			this.btnShortKey.Text = "set";
			// 
			// btnIniLoad
			// 
			this.btnIniLoad.Location = new System.Drawing.Point(384, 48);
			this.btnIniLoad.Name = "btnIniLoad";
			this.btnIniLoad.Size = new System.Drawing.Size(112, 23);
			this.btnIniLoad.TabIndex = 47;
			this.btnIniLoad.Text = "Load Config";
			// 
			// btnIniSave
			// 
			this.btnIniSave.Location = new System.Drawing.Point(264, 48);
			this.btnIniSave.Name = "btnIniSave";
			this.btnIniSave.Size = new System.Drawing.Size(112, 23);
			this.btnIniSave.TabIndex = 46;
			this.btnIniSave.Text = "Save Config";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 51;
			this.label1.Text = "Hide/Show TabPage List:";
			// 
			// btnPageHide
			// 
			this.btnPageHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPageHide.Location = new System.Drawing.Point(0, 185);
			this.btnPageHide.Name = "btnPageHide";
			this.btnPageHide.Size = new System.Drawing.Size(64, 19);
			this.btnPageHide.TabIndex = 48;
			this.btnPageHide.Text = "Hide";
			// 
			// btnPageShow
			// 
			this.btnPageShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPageShow.Location = new System.Drawing.Point(64, 185);
			this.btnPageShow.Name = "btnPageShow";
			this.btnPageShow.Size = new System.Drawing.Size(64, 19);
			this.btnPageShow.TabIndex = 49;
			this.btnPageShow.Text = "Show";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(416, 24);
			this.label2.TabIndex = 51;
			this.label2.Text = "this has been developed by personally.";
			// 
			// PageAbout
			// 
			this.Controls.Add(this.lstPage);
			this.Controls.Add(this.txtShortKey);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnShortKey);
			this.Controls.Add(this.btnIniLoad);
			this.Controls.Add(this.btnIniSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnPageHide);
			this.Controls.Add(this.btnPageShow);
			this.Controls.Add(this.label2);
			this.Name = "PageAbout";
			this.Size = new System.Drawing.Size(496, 208);
			this.ResumeLayout(false);

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

	}
}
