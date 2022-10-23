using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Autorization
{
    public partial class AnimateComponent : Component
    {
        private Form _sourceForm; // переменная для последующего задавания анимации форме
        private FormAnimatedEffects _closeEffect = FormAnimatedEffects.ПОЯВЛЕНИЕ_ЗАТУХАНИЕ; // создаем переменные для анимация
        private FormAnimatedEffects _accriveEffect = FormAnimatedEffects.РАСКРЫТИЕ_СКРЫТИЕ;
        public FormAnimatedEffects CloseEffect // запись свойства для анимации
        {
            get => _closeEffect;
            set => _closeEffect = value;
        }
        public FormAnimatedEffects AccriveEffect // запись свойства для анимации
        {
            get => _accriveEffect;
            set => _accriveEffect = value;
        }
        public Control SourceForm // свойство для передачи анимации форме
        {
            get => _sourceForm;
            set
            {
                if (value is Form)
                    _sourceForm = (value as Form);
            }
        }
        public AnimateComponent()
        {
            InitializeComponent();
        }
        public AnimateComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        [DllImport("user32")] // DLL
        static extern bool AnimateWindow(IntPtr hwnd, int time, uint flags); // переменные для поределения анимации в пространстве и времени
        public void ShowForm(int millisecond)
        {
            AnimateWindow(_sourceForm.Handle, millisecond, (uint)_accriveEffect | 0x00020000); // сам эффект для формы
            _sourceForm.Show();
        }
        public void CloseForm(int millisecond)
        {
            AnimateWindow(_sourceForm.Handle, millisecond, (uint)_accriveEffect | 0x00010000); // сам эффект для формы
            _sourceForm.Close();
        }
    }
}
