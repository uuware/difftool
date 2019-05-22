using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MainModule
{
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		//ext data that saved for TabPage
		public class TabPageDatas
		{
			private Hashtable tbl = new Hashtable();
			public int ActiveIndex = -1;
			public int Count = -1;
			public class TabPageData
			{
				//for show/hide page
				public TabPage page = null;
				public bool PageVisible = true;
				//for msg
				public int MsgHeight = 50;
				public bool MsgVisible = true;
			}

			/// <summary>
			/// get/set value of one page
			/// </summary>
			public TabPageData this[int nIndex]
			{
				get
				{
					if(tbl[nIndex] == null)
					{
						tbl[nIndex] = new TabPageData();
						if(Count < nIndex + 1)
						{
							Count = nIndex + 1;
						}
					}
					return (TabPageData)tbl[nIndex];
				}
				set
				{
					tbl[nIndex] = value;
					if(Count < nIndex + 1)
					{
						Count = nIndex + 1;
					}
				}
			}
		}
		private cc.Msg ccMsg;
		private TabPageDatas tabData = new TabPageDatas();

		private System.Windows.Forms.StatusBarPanel statusMsg;
		private System.Windows.Forms.StatusBarPanel statusLog;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabAbout;
		private System.Windows.Forms.Button btnIniLoad;
		private System.Windows.Forms.Button btnIniSave;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnShortKey;
		private System.Windows.Forms.TextBox txtShortKey;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.RichTextBox txtMsg;
		private System.Windows.Forms.StatusBarPanel statusLogClr;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnPageHide;
		private System.Windows.Forms.Button btnPageShow;
		private System.Windows.Forms.ListBox lstPage;
		private System.Windows.Forms.ListBox lstPageHide;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusMsg = new System.Windows.Forms.StatusBarPanel();
            this.statusLog = new System.Windows.Forms.StatusBarPanel();
            this.statusLogClr = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.lstPageHide = new System.Windows.Forms.ListBox();
            this.lstPage = new System.Windows.Forms.ListBox();
            this.txtShortKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnShortKey = new System.Windows.Forms.Button();
            this.btnIniLoad = new System.Windows.Forms.Button();
            this.btnIniSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPageHide = new System.Windows.Forms.Button();
            this.btnPageShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLogClr)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 319);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusMsg,
            this.statusLog,
            this.statusLogClr});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(642, 19);
            this.statusBar.TabIndex = 0;
            this.statusBar.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.statusBar_DrawItem);
            this.statusBar.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar_PanelClick);
            // 
            // statusMsg
            // 
            this.statusMsg.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.Text = "ready";
            this.statusMsg.ToolTipText = "message for you";
            this.statusMsg.Width = 505;
            // 
            // statusLog
            // 
            this.statusLog.Name = "statusLog";
            this.statusLog.Text = "Hide Log";
            this.statusLog.ToolTipText = "click here to hide/show log";
            this.statusLog.Width = 60;
            // 
            // statusLogClr
            // 
            this.statusLogClr.Name = "statusLogClr";
            this.statusLogClr.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.statusLogClr.Text = "Clear Log";
            this.statusLogClr.Width = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 74);
            this.panel1.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(642, 74);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.Text = "";
            this.txtMsg.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 241);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(642, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 241);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.lstPageHide);
            this.tabAbout.Controls.Add(this.lstPage);
            this.tabAbout.Controls.Add(this.txtShortKey);
            this.tabAbout.Controls.Add(this.label9);
            this.tabAbout.Controls.Add(this.btnShortKey);
            this.tabAbout.Controls.Add(this.btnIniLoad);
            this.tabAbout.Controls.Add(this.btnIniSave);
            this.tabAbout.Controls.Add(this.label1);
            this.tabAbout.Controls.Add(this.btnPageHide);
            this.tabAbout.Controls.Add(this.btnPageShow);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(634, 215);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            // 
            // lstPageHide
            // 
            this.lstPageHide.ItemHeight = 12;
            this.lstPageHide.Items.AddRange(new object[] {
            "#this is not show,only for set pages",
            "PageDirDiff",
            "PageDirClear",
            "PageAbout",
            "PageDirDiff"});
            this.lstPageHide.Location = new System.Drawing.Point(278, 103);
            this.lstPageHide.Name = "lstPageHide";
            this.lstPageHide.Size = new System.Drawing.Size(260, 64);
            this.lstPageHide.TabIndex = 45;
            this.lstPageHide.Visible = false;
            // 
            // lstPage
            // 
            this.lstPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPage.ItemHeight = 12;
            this.lstPage.Location = new System.Drawing.Point(0, 28);
            this.lstPage.Name = "lstPage";
            this.lstPage.Size = new System.Drawing.Size(307, 136);
            this.lstPage.TabIndex = 45;
            // 
            // txtShortKey
            // 
            this.txtShortKey.BackColor = System.Drawing.SystemColors.Info;
            this.txtShortKey.Enabled = false;
            this.txtShortKey.Location = new System.Drawing.Point(317, 65);
            this.txtShortKey.Name = "txtShortKey";
            this.txtShortKey.ReadOnly = true;
            this.txtShortKey.Size = new System.Drawing.Size(201, 21);
            this.txtShortKey.TabIndex = 44;
            this.txtShortKey.Text = "D1(49) + Control";
            this.txtShortKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtShortKey_KeyUp);
            this.txtShortKey.Leave += new System.EventHandler(this.txtShortKey_Leave);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(317, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(221, 18);
            this.label9.TabIndex = 43;
            this.label9.Text = "Key for Hide/Show this window:";
            // 
            // btnShortKey
            // 
            this.btnShortKey.Location = new System.Drawing.Point(518, 65);
            this.btnShortKey.Name = "btnShortKey";
            this.btnShortKey.Size = new System.Drawing.Size(77, 22);
            this.btnShortKey.TabIndex = 42;
            this.btnShortKey.Text = "set";
            this.btnShortKey.Click += new System.EventHandler(this.btnShortKey_Click);
            // 
            // btnIniLoad
            // 
            this.btnIniLoad.Location = new System.Drawing.Point(461, 9);
            this.btnIniLoad.Name = "btnIniLoad";
            this.btnIniLoad.Size = new System.Drawing.Size(134, 27);
            this.btnIniLoad.TabIndex = 7;
            this.btnIniLoad.Text = "Load Config";
            this.btnIniLoad.Click += new System.EventHandler(this.btnIniLoad_Click);
            // 
            // btnIniSave
            // 
            this.btnIniSave.Location = new System.Drawing.Point(317, 9);
            this.btnIniSave.Name = "btnIniSave";
            this.btnIniSave.Size = new System.Drawing.Size(134, 27);
            this.btnIniSave.TabIndex = 6;
            this.btnIniSave.Text = "Save Config";
            this.btnIniSave.Click += new System.EventHandler(this.btnIniSave_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 19);
            this.label1.TabIndex = 43;
            this.label1.Text = "Hide/Show TabPage List:";
            // 
            // btnPageHide
            // 
            this.btnPageHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPageHide.Location = new System.Drawing.Point(0, 188);
            this.btnPageHide.Name = "btnPageHide";
            this.btnPageHide.Size = new System.Drawing.Size(77, 22);
            this.btnPageHide.TabIndex = 42;
            this.btnPageHide.Text = "Hide";
            this.btnPageHide.Click += new System.EventHandler(this.btnPageHide_Click);
            // 
            // btnPageShow
            // 
            this.btnPageShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPageShow.Location = new System.Drawing.Point(77, 188);
            this.btnPageShow.Name = "btnPageShow";
            this.btnPageShow.Size = new System.Drawing.Size(77, 22);
            this.btnPageShow.TabIndex = 42;
            this.btnPageShow.Text = "Show";
            this.btnPageShow.Click += new System.EventHandler(this.btnPageShow_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(642, 338);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Name = "frmMain";
            this.Text = "lazyTools";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLogClr)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			ccMsg = new cc.Msg(txtMsg);

			// add ver to title
			System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
			string sver = System.Diagnostics.FileVersionInfo.GetVersionInfo(ass.Location).FileVersion;
			this.Text = this.Text + " (Version:" + sver + ") - uuware.com";
			
			//all tabpages, for set Init,and load it
			lstPage.Items.Clear();
			//add first page
			//tabData[0].page = tabControl1.TabPages[0];
			//tabControl1.TabPages[0].Name = "0";
			//lstPage.Items.Add("About - something about this project");
            //lstPageHide has this pages for load

            TabPage page1 = new TabPage("Diff");
            TabPage page2 = new TabPage("Clear");
            TabPage page3 = new TabPage("About");
            PageDirDiff pDiff = new PageDirDiff();
            PageDirClear pClear = new PageDirClear();
            PageAbout2 pAbout = new PageAbout2();
            tabControl1.TabPages.Clear();
            page1.Controls.Add(pDiff);
            page2.Controls.Add(pClear);
            page3.Controls.Add(pAbout);
            pDiff.Dock = DockStyle.Fill;
            pClear.Dock = DockStyle.Fill;
            pAbout.Dock = DockStyle.Fill;
            pDiff.frmMain = this;
            pClear.frmMain = this;
            pAbout.frmMain = this;
            tabControl1.TabPages.Add(page1);
            tabControl1.TabPages.Add(page2);
            tabControl1.TabPages.Add(page3);

            if (false)
            for (int i = 0; i < lstPageHide.Items.Count; i++)
			{
				string sItem = lstPageHide.Items[i].ToString();
				if(!sItem.Equals("") && !sItem.StartsWith("#"))
				{
					if(sItem.IndexOf(".") < 0)
					{
						sItem = this.CompanyName + "." + sItem;
					}
					Type ctlType = Type.GetType(sItem);
					if(ctlType != null && ctlType.BaseType.Name.Equals("UserControl"))
					{
						object obj = System.Reflection.Assembly.GetAssembly(ctlType).CreateInstance(sItem);
						Control userCtl = (Control)obj;
						System.Reflection.MethodInfo method = ctlType.GetMethod("Init");
						if(method != null && method.GetParameters().Length == 1)
						{
							method.Invoke(userCtl, new object[]{this});
						}
						else
						{
							msg.println("Error when load page:" + sItem, Color.Red);
						}
						string sTitle;
						System.Reflection.PropertyInfo property = ctlType.GetProperty("Title");
						if(property != null)
						{
							sTitle = (string)property.GetValue(userCtl, null);
						}
						else
						{
							sTitle = "NewPage";
						}
						string sComment;
						System.Reflection.PropertyInfo property2 = ctlType.GetProperty("Comment");
						if(property2 != null)
						{
							sComment = (string)property2.GetValue(userCtl, null);
						}
						else
						{
							sComment = "Comment for this page";
						}

						//add comment to list,for show/hide them
						lstPage.Items.Add(sTitle + " - " + sComment);
						//index for page.Name and tabData's index
						int nIndex = lstPage.Items.Count - 1;
						TabPage page = new TabPage(sTitle);
						page.Name = "" + nIndex;
						page.ToolTipText = sComment;
						page.Controls.Add(userCtl);
						userCtl.Dock = DockStyle.Fill;
						//page is add at Config_Load
						//tabControl1.TabPages.Add(page);
						tabData[nIndex].page = page;
					}
				}
			}

			Config_Load(Application.ExecutablePath + ".ini");
		}

		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			isClosing = true;
			if(isRunning)
			{
				isCanceling = true;
				e.Cancel = true;
			}
			else
			{
				Config_Save(Application.ExecutablePath + ".ini");
			}
		}

		void Config_Load(string sFileName)
		{
			System.Collections.Specialized.NameValueCollection coll = cc.Util.ReadIni(sFileName);
			if(coll == null)
			{
				coll = new System.Collections.Specialized.NameValueCollection();
			}
			try
			{
				if(coll["windows_x"] != null && coll["windows_y"] != null)
				{
					this.Location = new System.Drawing.Point(int.Parse(coll["windows_y"])
						, int.Parse(coll["windows_y"]));
				}
				if(coll["windows_w"] != null && coll["windows_h"] != null)
				{
					this.Size = new System.Drawing.Size(int.Parse(coll["windows_w"])
						, int.Parse(coll["windows_h"]));
				}
				if(coll.Get("windows_state") != null)
				{
					if(coll.Get("windows_state").Equals("Maximized"))
					{
						WindowState = FormWindowState.Maximized;
					}
					else if(coll.Get("windows_state").Equals("Minimized"))
					{
						WindowState = FormWindowState.Minimized;
					}
				}
			}
			catch
			{
			}

			//get all tabpage's info
            if(false)
			for(int i = 0; i < tabData.Count; i++)
			{
				try
				{
					if(coll["MsgHeight" + i] != null)
					{
						tabData[i].MsgHeight = int.Parse(coll["MsgHeight" + i]);
					}
					if(coll["MsgVisible" + i] != null)
					{
						tabData[i].MsgVisible = coll["MsgVisible" + i].Equals("True");
					}
					if(coll["PageVisible" + i] != null)
					{
						tabData[i].PageVisible = coll["PageVisible" + i].Equals("True");
					}
				}
				catch
				{
				}
			}

			//all sub pages
            if(false)
			for(int i = 0; i < tabData.Count; i++)
			{
				if(tabData[i].page != null && tabData[i].page.Controls.Count > 0)
				{
					Control userCtl = tabData[i].page.Controls[0];
					System.Type ctlType = userCtl.GetType();
					if(ctlType.BaseType != null && ctlType.BaseType.Name.Equals("UserControl"))
					{
						System.Reflection.MethodInfo method = ctlType.GetMethod("Config_Load");
						if(method != null)
						{
							method.Invoke(userCtl, new object[]{coll});
						}
					}
					//add this page,avoid About page
					if(tabData[i].PageVisible && i != 0)
					{
						tabControl1.TabPages.Add(tabData[i].page);
					}
				}
			}
			if(coll["activate_tab"] != null)
			{
				for(int i = 0; i < tabControl1.TabPages.Count; i++)
				{
					if(tabControl1.TabPages[i].Name.Equals(coll["activate_tab"]))
					{
						tabControl1.SelectedIndex = i;
						break;
					}
				}
			}
		}

		void Config_Save(string sFileName)
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(sFileName, false, System.Text.Encoding.Default);
			sw.Write("#ini file for " + this.CompanyName + " - made by NewCon.ShuKK\r\n");
			sw.Write("windows_state={0}\r\n", this.WindowState);
			if(WindowState != FormWindowState.Normal)
			{
				WindowState = FormWindowState.Normal;
			}
			sw.Write("windows_x={0}\r\n", this.Location.X);
			sw.Write("windows_y={0}\r\n", this.Location.Y);
			sw.Write("windows_w={0}\r\n", this.Size.Width);
			sw.Write("windows_h={0}\r\n", this.Size.Height);
			sw.Write("activate_tab={0}\r\n", tabControl1.SelectedTab.Name);

			//save all tabpage's info
			if(txtMsg.Visible)
			{
				try
				{
					//tabData[int.Parse(tabControl1.SelectedTab.Name)].MsgHeight = panel1.Height;
				}
				catch
				{
				}
			}
            if(false)
			for(int i = 0; i < tabData.Count; i++)
			{
				sw.Write("MsgHeight{0}={1}\r\n", i, tabData[i].MsgHeight);
				sw.Write("MsgVisible{0}={1}\r\n", i, tabData[i].MsgVisible);
				if(tabControl1.TabPages.IndexOf(tabData[i].page) != -1)
				{
					sw.Write("PageVisible{0}=True\r\n", i);
				}
				else
				{
					sw.Write("PageVisible{0}=False\r\n", i);
				}
			}

			//all sub pages
            if(false)
			for(int i = 0; i < tabData.Count; i++)
			{
				if(tabData[i].page != null && tabData[i].page.Controls.Count > 0)
				{
					Control userCtl = tabData[i].page.Controls[0];
					System.Type ctlType = userCtl.GetType();
					if(ctlType.BaseType != null && ctlType.BaseType.Name.Equals("UserControl"))
					{
						System.Reflection.MethodInfo method = ctlType.GetMethod("Config_Save");
						if(method != null)
						{
							method.Invoke(userCtl, new object[]{sw});
						}
					}
				}
			}

			sw.Flush();
			sw.Close();
		}

		private void txtMsg_TextChanged(object sender, System.EventArgs e)
		{
			//if log is hidden then when logging,show red panel text
			if(panel1.Visible == false && !txtMsg.Text.Equals(""))
			{
				statusBrush = new SolidBrush(Color.Red);
				statusBar.Refresh();
			}
		}

		private void txtMsg_ShowHide()
		{
			if(panel1.Visible)
			{
				statusLog.Text = "Show Log";
				txtMsg.Visible = false;
				panel1.Visible = false;
                splitter1.Visible = false;
            }
            else
			{
				statusLog.Text = "Hide Log";
				txtMsg.Visible = true;
				panel1.Visible = true;
                splitter1.Visible = true;

            }
		}
		private void statusBar_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
			string sTxt = e.StatusBarPanel.Text;
			if(sTxt.Equals("Show Log") || sTxt.Equals("Hide Log"))
			{
				txtMsg_ShowHide();
			}
			else if(sTxt.Equals("Clear Log"))
			{
				txtMsg.Clear();
				statusBrush = new SolidBrush(Color.Black);
				statusBar.Refresh();
			}
		}

		private SolidBrush statusBrush = new SolidBrush(Color.Black);
		private void statusBar_DrawItem(object sender, System.Windows.Forms.StatusBarDrawItemEventArgs sbdevent)
		{
			Graphics g = sbdevent.Graphics;
			StatusBar sb = (StatusBar)sender;
			g.DrawString("Clear Log", sb.Font, statusBrush, sbdevent.Bounds.X, sbdevent.Bounds.Y);
		}

		//page About 
		SolidBrush brushBlack = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
		private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			string tabName = tabControl1.TabPages[e.Index].Text;
			SolidBrush brush;
			int posX;
			if(e.Index == this.tabControl1.SelectedIndex)
			{
				brush = new SolidBrush(Color.Red);
				posX = 5;
			}
			else
			{
				brush = new SolidBrush(Color.Black);
				posX = 2;
			}
			TabControl tab = (TabControl)sender;
			e.Graphics.FillRectangle(brushBlack, e.Bounds);
			e.Graphics.DrawString(tabName, tab.Font, brush, e.Bounds.X + posX, e.Bounds.Y + 3);
			brush.Dispose();
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            return;
			//when remove pages,avoid for auto selected
			if(nPageShowHideIndex != -1)
			{
				tabControl1.SelectedIndex = nPageShowHideIndex;
				nPageShowHideIndex = -1;
				return;
			}
			int nOldIndex = tabData.ActiveIndex;
			int nNewIndex = tabControl1.SelectedIndex;
			if(nOldIndex == -1)
			{
				tabData.ActiveIndex = nNewIndex;
				if(tabData[nNewIndex].MsgVisible != txtMsg.Visible)
				{
					txtMsg_ShowHide();
				}
				if(txtMsg.Visible)
				{
					int nHeight = tabData[nNewIndex].MsgHeight;
					if(nHeight > this.Height - 80)
					{
						nHeight = this.Height - 80;
					}
					panel1.Height = nHeight;
				}
				return;
			}
			if(nOldIndex != nNewIndex && txtMsg.Visible)
			{
				tabData[nOldIndex].MsgHeight = panel1.Height;
			}
			tabData.ActiveIndex = nNewIndex;

			if(!tabData[nNewIndex].MsgVisible && !txtMsg.Visible)
			{
				return;
			}
			if((tabData[nNewIndex].MsgVisible != !txtMsg.Visible))
			{
				panel1.Height = tabData[nNewIndex].MsgHeight;
				txtMsg_ShowHide();
			}
			else
			{
				if(tabData[nNewIndex].MsgHeight == 0
					|| tabData[nNewIndex].MsgHeight == panel1.Height)
				{
					return;
				}
				int nHeight = tabData[nNewIndex].MsgHeight;
				if(nHeight > this.Height - 80)
				{
					nHeight = this.Height - 80;
				}
				panel1.Height = nHeight;
			}
		}

		int nPageShowHideIndex = -1;
		private void btnPageHide_Click(object sender, System.EventArgs e)
		{
            return;
			if(lstPage.SelectedIndex < 0)
			{
				status.Text = "need select item";
				return;
			}
			if(lstPage.Items[lstPage.SelectedIndex].ToString().StartsWith("About"))
			{
				status.Text = "can not hide this page";
				return;
			}
			string sIndex = "" + lstPage.SelectedIndex;
			bool hasPage = false;
			//delete this page
			for(int i = 0; i < tabControl1.TabPages.Count; i++)
			{
				if(tabControl1.TabPages[i].Name.Equals(sIndex))
				{
					//when remove pages,avoid for auto selected
					nPageShowHideIndex = 0;
					tabControl1.Visible = false;
					tabControl1.TabPages.RemoveAt(i);
					tabControl1.Visible = true;
					nPageShowHideIndex = -1;
					hasPage = true;
					break;
				}
			}
			if(!hasPage)
			{
				status.Text = "can not hide this page";
			}
		}

		private void btnPageShow_Click(object sender, System.EventArgs e)
		{
			if(lstPage.SelectedIndex < 0)
			{
				status.Text = "need select item";
				return;
			}
			if(lstPage.Items[lstPage.SelectedIndex].ToString().StartsWith("About"))
			{
				status.Text = "this page is showing";
				return;
			}
			string sIndex = "" + lstPage.SelectedIndex;
			bool hasPage = false;
			//detect this page
			for(int i = 0; i < tabControl1.TabPages.Count; i++)
			{
				if(tabControl1.TabPages[i].Name.Equals(sIndex))
				{
					hasPage = true;
					break;
				}
			}
			if(!hasPage)
			{
				tabControl1.TabPages.Add(tabData[lstPage.SelectedIndex].page);
			}
			else
			{
				status.Text = "this page is showing";
			}
		}

		private void btnShortKey_Click(object sender, System.EventArgs e)
		{
			txtShortKey.Enabled = true;
			txtShortKey.Focus();
		}

		private void txtShortKey_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if((int)e.KeyCode < 16 || (int)e.KeyCode > 18)
			{
				string sKey = "" + e.KeyCode + "(" + (int)e.KeyCode + ")";
				if(sKey.Equals(""))
				{
					return;
				}
				if(e.Alt)
				{
					sKey += " + Alt";
				}
				if(e.Control)
				{
					sKey += " + Control";
				}
				if(e.Shift)
				{
					sKey += " + Shift";
				}
				txtShortKey.Text = sKey;
				txtShortKey.Enabled = false;
			}
		}

		private void txtShortKey_Leave(object sender, System.EventArgs e)
		{
			txtShortKey.Enabled = false;
		}

		private void btnIniSave_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog openFileDialog1 = new SaveFileDialog();
			openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
			openFileDialog1.Filter = "Config file(*.ini; *.txt)|*.ini; *.txt";
			openFileDialog1.Title = "Save config file";

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Config_Save(openFileDialog1.FileName);
			}		
		}

		private void btnIniLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
			openFileDialog1.Filter = "Config file(*.ini; *.txt)|*.ini; *.txt";
			openFileDialog1.Title = "Load config file";

			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Config_Load(openFileDialog1.FileName);
			}		
		}


	
	
	
	
	
	
	
	
	
	
		public cc.Msg msg
		{
			get
			{
				return ccMsg;
			}
		}
		public StatusBarPanel status
		{
			get
			{
				return statusMsg;
			}
		}
	
		bool bisRunning = false;
		/// <summary>
		/// Runningを取得
		/// </summary>
		public bool isRunning
		{
			get
			{
				if(bisCanceling)
				{
					return true;
				}
				else
				{
					return bisRunning;
				}
			}
			set
			{
				bisRunning = value;
			}
		}

		bool bisCanceling = false;
		/// <summary>
		/// Cancelingを取得
		/// </summary>
		public bool isCanceling
		{
			get
			{
				if(bisClosing)
				{
					return true;
				}
				else if(!bisRunning)
				{
					return false;
				}
				else
				{
					return bisCanceling;
				}
			}
			set
			{
				bisCanceling = value;
			}
		}

		
		bool bisClosing = false;
		/// <summary>
		/// Cancelingを取得
		/// </summary>
		public bool isClosing
		{
			get
			{
				return bisClosing;
			}
			set
			{
				bisClosing = value;
			}
		}
	}
}
