using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Sayso.Domain
{
    #region A Square is not a rectangle

    public class Rectangle
    {
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }
    }

    public class Square : Rectangle
    {
        public override double Height
        {
            get { return base.Height; }
            set
            {
                // LSP Violation!!!
                base.Height = value;
                base.Width = value;
            }
        }

        public override double Width
        {
            get { return base.Width; }
            set
            {
                // LSP Violation
                base.Width = value;
                base.Height = value;
            }
        }
    }

    [TestFixture]
    public class SquareFixture
    {
        [Test]
        public void ShouldNotBeSurprisedWhenSettingAProperty()
        {
            var square = new Square();

            square.Width = 42;
            square.Height = 10;

            Assert.That(square.Width, Is.EqualTo(42));
            Assert.That(square.Height, Is.EqualTo(10));
        }
    }

    #endregion

    #region .NET Framework example

    [TestFixture]
    public class LiskovSubstitutionPrincipleViolationFixture
    {
        [Test]
        public void ShouldAddItemToList()
        {
            IList<int> list = new List<int>();
            list.Add(42);

            Assert.That(list, Has.Member(42));
        }

        [Test]
        public void ShouldAddItemToArray() {
            IList<int> list = new int[1];
            list.Add(42);

            Assert.That(list, Has.Member(42));
        }
    }

    #endregion
}