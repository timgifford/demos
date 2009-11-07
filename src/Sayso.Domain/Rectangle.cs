namespace Sayso.Domain
{
    public class Rectangle {
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }
    }

    public class Square : Rectangle {
        public override double Height {
            get {
                return base.Height;
            }
            set {
                // LSP Violation!!!
                base.Height = value;
                base.Width = value;
            }
        }

        public override double Width {
            get {
                return base.Width;
            }
            set {
                // LSP Violation
                base.Width = value;
                base.Height = value;
            }
        }
    }

}