using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorization
{
    public partial class AnimateComponent : Component
    {
        #region [ Поля класса ]
        private Form _sourceForm;
        private FormAnimatedEffects _closeEffect = FormAnimatedEffects.ПОЯВЛЕНИЕ_ЗАТУХАНИЕ;
        private FormAnimatedEffects _accriveEffect = FormAnimatedEffects.РАСКРЫТИЕ_СКРЫТИЕ;
        #endregion
        #region [ Свойства класса ]
        public FormAnimatedEffects CloseEffect
        {
            get => _closeEffect;
            set => _closeEffect = value;
        }
        public FormAnimatedEffects AccriveEffect
        {
            get => _accriveEffect;
            set => _accriveEffect = value;
        }
        public Control SourceForm
        {
            get => _sourceForm;
            set
            {
                if (value is Form)
                    _sourceForm = (value as Form);
            }
        }
        #endregion

        public AnimateComponent()
        {
            InitializeComponent();
        }

        public AnimateComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #region [ Методы ]
        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, uint flags);

        public void ShowForm(int millisecond)
        {
            AnimateWindow(_sourceForm.Handle, millisecond, (uint)_accriveEffect | 0x00020000);
            _sourceForm.Show();
        }
        public void CloseForm(int millisecond)
        {
            AnimateWindow(_sourceForm.Handle, millisecond, (uint)_accriveEffect | 0x00010000);
            _sourceForm.Close();
        }
        #endregion
    }
}
