using System.Drawing;

namespace Autorization
{
    class ThemeMethodClass
    {
        static public class Theme // Класс для смены темы с темной на светлую, и наоборот, во всей программе
        { 
            static public Color LightColor = Color.DeepSkyBlue; // светлая тема для верхней панели (цвет DeepSkyBlue = голубой)
            static public Color LightColor2 = Color.Lavender; // светлая тема для нижней панели (цвет Lavender = розовый)
            static public Color DarkColor = Color.Gray; // темная тема для верхней панели (цвет Gray = серый)
            static public Color DarkColor2 = Color.DarkGray; // темная тема для нижней панели (цвет DarkGray = темносерый)
        }
    }
}
