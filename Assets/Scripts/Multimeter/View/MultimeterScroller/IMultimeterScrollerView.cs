namespace Multimeter.View
{
    public interface IMultimeterScrollerView
    {
        public void Highlight(bool isHighlighted);

        public void SetScrollerPosition(PhysicalQuantityType physicalQuantity);
    }
}