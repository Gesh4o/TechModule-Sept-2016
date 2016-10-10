namespace ObjectsAndClasses
{
    using System;
    using System.Linq;

    class RectanglePositionMain
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = ReadRectangle();
            Rectangle rect2 = ReadRectangle();

            if (rect1.IsInside(rect2))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");

            }
        }

        static Rectangle ReadRectangle()
        {
            // Reads a line and parse it to int array.
            int[] rectInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // Create rectangle object with the following properties.
            Rectangle rect = new Rectangle()
            {
                Left = rectInfo[0],
                Top = rectInfo[1],
                Width = rectInfo[2],
                Height = rectInfo[3]
            };

            return rect;
        }
    }

    class Rectangle
    {
        public int Left { get; set; }

        public int Top { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        // Calculated property.
        public int Right
        {
            get
            {
                return Left + Width;
            }
        }

        // Calculated property.
        public int Bot
        {
            get
            {
                return Top + Height;
            }
        }

        public bool IsInside(Rectangle rectangle)
        {
            // Disclaimer: the variables: "Top","Bot" and so on are reference to our current object.
            // We will compare them with the values of the passed object named "rectangle".
            bool isInside = Top >= rectangle.Top && Bot <= rectangle.Bot && Left >= rectangle.Left && Right <= rectangle.Right;
            return isInside;
        }
    }
}
