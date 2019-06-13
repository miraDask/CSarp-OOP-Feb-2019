using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape rectangle = new Rectangle();
            IShape circle = new Circle();

            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(rectangle);
        }
    }
}
