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
	public class PageAbout2 : System.Windows.Forms.UserControl
	{
		public frmMain frmMain = null;
		private System.Windows.Forms.Button btnIniLoad;
		private System.Windows.Forms.Button btnIniSave;
		private System.Windows.Forms.Label label2;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PageAbout2()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageAbout2));
            this.btnIniLoad = new System.Windows.Forms.Button();
            this.btnIniSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIniLoad
            // 
            this.btnIniLoad.Location = new System.Drawing.Point(127, 17);
            this.btnIniLoad.Name = "btnIniLoad";
            this.btnIniLoad.Size = new System.Drawing.Size(112, 23);
            this.btnIniLoad.TabIndex = 47;
            this.btnIniLoad.Text = "Load Config";
            // 
            // btnIniSave
            // 
            this.btnIniSave.Location = new System.Drawing.Point(7, 17);
            this.btnIniSave.Name = "btnIniSave";
            this.btnIniSave.Size = new System.Drawing.Size(112, 23);
            this.btnIniSave.TabIndex = 46;
            this.btnIniSave.Text = "Save Config";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(419, 102);
            this.label2.TabIndex = 51;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // PageAbout2
            // 
            this.Controls.Add(this.btnIniLoad);
            this.Controls.Add(this.btnIniSave);
            this.Controls.Add(this.label2);
            this.Name = "PageAbout2";
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
