/*Modify List:
 * 20050725,Color&Font add
 * 
 */
using System;

	/// <summary>
	/// Common Class
	/// </summary>
namespace cc
{
	/// <summary>
	/// Msg
	/// </summary>
	public class Msg
	{
		private System.Windows.Forms.RichTextBox txtMsg;
		//�f�t�H���gFont, Color
		private System.Drawing.Font defaultFont;
		private System.Drawing.Color defaultColor;
		public Msg(System.Windows.Forms.RichTextBox txtMsg)
		{
			this.txtMsg = txtMsg;
			//�f�t�H���gFont, Color�̐ݒ�
			defaultFont = txtMsg.Font;
			defaultColor = txtMsg.ForeColor;
		}

		/// <summary>
		/// �f�t�H���gFont�̐ݒ�Ǝ擾
		/// </summary>
		public System.Drawing.Font DefaultFont
		{
			get
			{
				return defaultFont;
			}
			set
			{
				defaultFont = value;
			}
		}

		/// <summary>
		/// �f�t�H���gColor�̐ݒ�Ǝ擾
		/// </summary>
		public System.Drawing.Color DefaultColor
		{
			get
			{
				return defaultColor;
			}
			set
			{
				defaultColor = value;
			}
		}

		/// <summary>
		/// ���b�Z�[�W�Ƀt�H�[�J�X���Z�b�g
		/// </summary>
		public void Focus()
		{
			txtMsg.Focus();
		}

		/// <summary>
		/// ���b�Z�[�W���N���A����
		/// </summary>
		public void clear()
		{
			txtMsg.Text = "";
		}

		/// <summary>
		/// ���b�Z�[�W���o��
		/// </summary>
		public void print(string msg)
		{
			print(msg, defaultColor, defaultFont);
		}
		/// <summary>
		/// �F���w�肵�A���b�Z�[�W���o��
		/// </summary>
		public void print(string msg, System.Drawing.Color cor)
		{
			print(msg, cor, defaultFont);
		}
		/// <summary>
		/// �t�H���g���w�肵�A���b�Z�[�W���o��
		/// </summary>
		public void print(string msg, System.Drawing.Font font)
		{
			print(msg, defaultColor, font);
		}
		/// <summary>
		/// �F�A�t�H���g���w�肵�A���b�Z�[�W���o��
		/// </summary>
		public void print(string msg, System.Drawing.Color cor, System.Drawing.Font font)
		{
			//�o��
			foreach(string s in msg.Split('\n'))
			{
				//�w��F��ݒ�
				txtMsg.SelectionLength = 0;
				txtMsg.SelectionStart = txtMsg.Text.Length;
				txtMsg.SelectionColor = cor;
				txtMsg.SelectionFont = font;
				txtMsg.AppendText(s);
				System.Windows.Forms.Application.DoEvents();
			}
		}

		/// <summary>
		/// ���s���A���b�Z�[�W���o��
		/// </summary>
		public void println(string msg)
		{
			print(msg + "\r\n", defaultColor, defaultFont);
		}
		/// <summary>
		/// �F���w�肵�A���s���A���b�Z�[�W���o��
		/// </summary>
		public void println(string msg, System.Drawing.Color cor)
		{
			print(msg + "\r\n", cor, defaultFont);
		}
		/// <summary>
		/// �t�H���g���w�肵�A���s���A���b�Z�[�W���o��
		/// </summary>
		public void println(string msg, System.Drawing.Font font)
		{
			print(msg + "\r\n", defaultColor, font);
		}
		/// <summary>
		/// �F�A�t�H���g���w�肵�A���s���A���b�Z�[�W���o��
		/// </summary>
		public void println(string msg, System.Drawing.Color cor, System.Drawing.Font font)
		{
			print(msg + "\r\n", cor, font);
		}
	}

}
