using System;
using System.Drawing;
using System.Windows.Forms;

namespace cc
{
	/// <summary>
	/// Summary description for SystemTrayNotifyIcon.
	/// </summary>
	public class SystemTrayNotification
	{
		/// <summary>
		/// Summary description for SystemTrayNotificationEventType.
		/// </summary>
		public enum SystemTrayNotificationEventType
		{
			Click,
			DoubleClick,
			MouseDown,
			MouseMove,
			MouseUp,
			Hiding,
			Showing,
			StartingAnimation,
			StopingAnimation,
			IconChanged,
			Disposing
		};

		/// <summary>
		/// Summary description for SystemTrayNotificationEventArgs.
		/// </summary>
		public class SystemTrayNotificationEventArgs : EventArgs
		{
			private SystemTrayNotificationEventType state;
			private System.Windows.Forms.MouseEventArgs e = null;

			public SystemTrayNotificationEventArgs(SystemTrayNotificationEventType state) : base()
			{
				this.state = state;
			}

			public SystemTrayNotificationEventArgs(SystemTrayNotificationEventType state,
				System.Windows.Forms.MouseEventArgs e) : base()
			{
				this.state = state;
				this.e = e;
			}

			public SystemTrayNotificationEventType State
			{
				get
				{
					return state;
				}
			}
			public System.Windows.Forms.MouseEventArgs MouseEventArgs
			{
				get
				{
					return e;
				}
			}
		}
	
		private System.Windows.Forms.NotifyIcon notifyIcon = new NotifyIcon();	// NotifyIcon object
		private System.Windows.Forms.ContextMenu BaseMenu;
		private System.Windows.Forms.Form mainForm;
		private System.Drawing.Icon [] iconArray;
		private System.Drawing.Icon mainIcon;
		private System.Windows.Forms.Timer iconTimer;
		private int timerInterval = 200;
		private int iconCounter = 0;
		private int totalAnimations = 0;
		private int animationCounter = 0;
		private bool iconsLoaded = false;
		private bool keepAnimationAlive = false;
		
		// Declaring Event 
		public delegate void StatusChanged(object sender, SystemTrayNotificationEventArgs e);
		public event StatusChanged OnStatusChanged;

		/// <summary>
		/// Property for showing and hiding icon
		/// </summary>
		public bool Visibility
		{
			get
			{
				return notifyIcon.Visible;
			}
			set
			{
				switch (value)
				{
					case true:
						if (notifyIcon.Visible == false)
						{
							OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.Showing));
						}
						break;
					case false:
						if (notifyIcon.Visible == true)
						{
							OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.Hiding));
						}
						break;
				}
				notifyIcon.Visible = value;
			}
		}

		/// <summary>
		/// Property
		/// </summary>
		public bool KeepAnimationAlive
		{
			get
			{
				return keepAnimationAlive;
			}
			set
			{
				switch (value)
				{
					case true:
						if (keepAnimationAlive == false)
							OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.StartingAnimation));
						break;
					case false:
						if (keepAnimationAlive == true)
							OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.StopingAnimation));
						break;
				}
				keepAnimationAlive = value;
			}
		}

		/// <summary>
		/// Overloaded Constructor -- 1 --
		/// Icon = Application Icon (Default),
		/// Tooltip = Application Name (Default),
		/// Visibility = Programmer must provide,
		/// ContextMenu = SystemTrayNotifyIcon class generated menu (Default).
		/// </summary>
		private void SystemTrayNotification_base(
			System.Windows.Forms.Form form,
			bool visible,
			string toolTip,
			Icon icon,
			ContextMenu contextMenu)
		{
			mainForm = form;
			notifyIcon.Visible = visible;
			if (toolTip != null)
			{
				notifyIcon.Text = toolTip;
			}
			else
			{
				notifyIcon.Text = mainForm.Text;
			}			
			// Setting Event Handler
			OnStatusChanged += new StatusChanged(SystemTrayNotificationHandler);
			if(icon !=  null && icon.Size.Height <= 16 && icon.Size.Width <= 16)
			{
				notifyIcon.Icon = icon;
			}
			else
			{
				notifyIcon.Icon = mainForm.Icon;
			}
			if(contextMenu != null)
			{
				notifyIcon.ContextMenu = contextMenu;
			}
			else
			{
				notifyIcon.ContextMenu = LoadDefaultContextMenu();
			}

			notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			notifyIcon.MouseDown += new  System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
			notifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseMove);
			notifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseUp);

			iconTimer = new Timer();
			iconTimer.Interval = timerInterval;
			iconTimer.Tick += new EventHandler(TimerProc);
		}

		/// <summary>
		/// Overloaded Constructor -- 1 --
		/// Icon = Application Icon (Default),
		/// Tooltip = Application Name (Default),
		/// Visibility = Programmer must provide,
		/// ContextMenu = SystemTrayNotifyIcon class generated menu (Default).
		/// </summary>
		public SystemTrayNotification(System.Windows.Forms.Form form, bool visible)
		{
			SystemTrayNotification_base(form, visible, null, null, null);
		}

		/// <summary>
		/// Overloaded Constructor -- 2 --
		/// Icon = Application Icon (Default),
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = SystemTrayNotifyIcon class generated menu (Default).
		/// </summary>
		public SystemTrayNotification(System.Windows.Forms.Form form, bool visible, string toolTip)
		{
			SystemTrayNotification_base(form, visible, toolTip, null, null);
		}

		/// <summary>
		/// Overloaded Constructor -- 3 --
		/// Icon = Programmer must provide,
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = SystemTrayNotifyIcon class generated menu (Default).
		/// </summary>
		public SystemTrayNotification(System.Windows.Forms.Form form, bool visible, string toolTip, Icon icon)
		{
			SystemTrayNotification_base(form, visible, toolTip, icon, null);
		}

		/// <summary>
		/// Overloaded Constructor -- 4 --
		/// Icon = Application Icon (Default),
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = Programmer must provide.
		/// </summary>
		public SystemTrayNotification(System.Windows.Forms.Form form, bool visible, string toolTip, ContextMenu contextMenu)
		{
			SystemTrayNotification_base(form, visible, toolTip, null, contextMenu);
		}

		/// <summary>
		/// Overloaded Constructor -- 5 --
		/// Icon = Programmer must provide,
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = Programmer must provide.
		/// </summary>
		public SystemTrayNotification(System.Windows.Forms.Form form, bool visible, string toolTip, Icon icon, ContextMenu contextMenu)
		{
			SystemTrayNotification_base(form, visible, toolTip, icon, contextMenu);
		}

		public void Dispose()
		{
			OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.Disposing));
			iconTimer.Tick -= new EventHandler(TimerProc);
			if(BaseMenu != null)
			{
				BaseMenu.Dispose();
			}
			notifyIcon.Dispose();
		}

		/// <summary>
		/// Loads a Default ContextMenu
		/// </summary>
		private ContextMenu LoadDefaultContextMenu()
		{
			BaseMenu = new System.Windows.Forms.ContextMenu();

			// Adding menu items
			BaseMenu.MenuItems.Add(new MenuItem("Hide Icon", new System.EventHandler(DefaultMenuHandler)));
			BaseMenu.MenuItems.Add(new MenuItem("-", new System.EventHandler(DefaultMenuHandler)));
			BaseMenu.MenuItems.Add(new MenuItem("Exit Application", new System.EventHandler(DefaultMenuHandler)));

			return BaseMenu;
		}

		/// <summary>
		/// notifyIcon's Event Handler
		/// </summary>
		private void notifyIcon_Click(object sender, System.EventArgs e)
		{
			OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.Click));
		}
		private void notifyIcon_DoubleClick(object sender, System.EventArgs e)
		{
			OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.DoubleClick));
		}
		private void notifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.MouseDown, e));
		}
		private void notifyIcon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.MouseMove, e));
		}
		private void notifyIcon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.MouseUp, e));
		}

		/// <summary>
		/// Default menu's Event Handler
		/// </summary>
		private void DefaultMenuHandler(object sender, System.EventArgs e) 
		{
			try 
			{
				switch (((MenuItem)sender).Text)
				{
					case "Animate":
						Animate(-1, 100);
						break;
					case "Stop Animation":
						OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.StopingAnimation));
						keepAnimationAlive = false;
						break;
					case "Hide Icon":
						OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.Hiding));
						notifyIcon.Visible = false;
						break;
					case "Exit Application":
						notifyIcon.Visible = false;
						mainForm.Close();
						break;
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message,"Error");
			}
		}

		/// <summary>
		/// Animation Initializer for showing animation in System Tray -- 
		/// nTimes = Programmer must provide,
		/// timeInterval = 1000 equals 1 Second (Default: 200).
		/// </summary>
		public void Animate(int nTimes)
		{
			if (!iconsLoaded)
			{
				MessageBox.Show("LoadIcons() must be called before Animate().", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if ((nTimes == -1) || (nTimes > 0))
			{
				if (BaseMenu != null)
				{
					BaseMenu.MenuItems.RemoveAt(0);
					BaseMenu.MenuItems.Add(0, new MenuItem("Stop Animation", new System.EventHandler(DefaultMenuHandler)));
				}
				totalAnimations = nTimes;
				OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.StartingAnimation));
				keepAnimationAlive = true;
				iconTimer.Start();
			}
		}

		/// <summary>
		/// Overloaded Animation Initializer for showing animation in System Tray -- 
		/// nTimes = Programmer must provide,
		/// timeInterval = Programmer must provide (1000 equals 1 Second) (Limit 50 - 50000).
		/// </summary>
		public void Animate(int nTimes, int timerinterval)
		{
			timerInterval = (timerinterval>50000 || timerinterval<50)?200:timerinterval;
			if (!iconsLoaded)
			{
				MessageBox.Show("LoadIcons() must be called before Animate().", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if ((nTimes == -1) || (nTimes > 0))
			{
				if (BaseMenu != null)
				{
					BaseMenu.MenuItems.RemoveAt(0);
					BaseMenu.MenuItems.Add(0, new MenuItem("Stop Animation", new System.EventHandler(DefaultMenuHandler)));
				}
				totalAnimations = nTimes;
				iconTimer.Interval = timerInterval;
				OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.StartingAnimation));
				keepAnimationAlive = true;
				iconTimer.Start();
			}
		}

		/// <summary>
		/// Loads default icons of size 16x16 for animation,
		/// </summary>
		public void LoadIcons(System.Drawing.Icon [] iconarray)
		{
			iconsLoaded = true;
			iconCounter = 0;
			totalAnimations = 0;
			mainIcon = notifyIcon.Icon;
			iconArray = iconarray;
			if (BaseMenu != null)
				BaseMenu.MenuItems.Add(0, new MenuItem("Animate", new System.EventHandler(DefaultMenuHandler)));

			for (int cnt = 1; cnt < iconArray.Length+1; cnt++)
			{
				try
				{
					if (iconArray[cnt-1].Size.Height > 16 || iconArray[cnt-1].Size.Width > 16)
					{
						iconArray[cnt-1] = mainForm.Icon;
					}
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Timer proc for showing animation effect in System Tray
		/// </summary>
		private void TimerProc(object sender, EventArgs e)
		{
			if (keepAnimationAlive == false)
			{
				iconTimer.Stop();
				iconCounter = 0;
				animationCounter = 0;
				notifyIcon.Icon = mainIcon;
				if (BaseMenu != null)
				{
					BaseMenu.MenuItems.RemoveAt(0);
					BaseMenu.MenuItems.Add(0, new MenuItem("Animate", new System.EventHandler(DefaultMenuHandler)));
				}
			}
			else
			{
				OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.IconChanged));
				notifyIcon.Icon = iconArray[iconCounter++];
				if (iconCounter == iconArray.Length)
				{
					iconCounter = 0;
					animationCounter++;
				}
				
				if ((animationCounter == totalAnimations) && (totalAnimations != -1))
				{
					animationCounter = 0;
					totalAnimations = 0;
					OnStatusChanged(this, new SystemTrayNotificationEventArgs(SystemTrayNotificationEventType.StopingAnimation));
					keepAnimationAlive = false;
				}
			}
		}
		
		/// <summary>
		/// Default Event Handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SystemTrayNotificationHandler(object sender, SystemTrayNotificationEventArgs e)
		{
			// This event handler is not required here exactly
			// It just facilitates the programmer to save him/her from
			// exceptions if he/she don't provides his/her own EventHandler
			// function
			/*
			switch (e.State)
			{
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.Click:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.DoubleClick:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.MouseDown:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.MouseMove:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.MouseUp:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.Hiding:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.Showing:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.StartingAnimation:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.StopingAnimation:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.IconChanged:
					break;
				case cc.SystemTrayNotification.SystemTrayNotificationEventType.Disposing:
					break;
				default:      
					break;
			}
			*/
		}
	}
}
