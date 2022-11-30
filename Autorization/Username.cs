namespace Autorization
{
    class Username // класс создан для успешной авторизации и проверки на роль пользователя
    {
        string name; // переменная для названия роли
        private int role; // переменная которая используется для указания роли аккаунтам, и описывает их функционал
        public static Username user1; // переменная для того чтобы можно было задать пользователю роль
        public int Role // свойство
        {
            get => role; // краткая запись свойства
        }
        public Username(string name,int role) // конструктор с передачей значений
        {
            this.role = role;
            user1 = this; // переданные значения передаем пользователю и проверем его роль
            this.name = name;
        }
    }
}
