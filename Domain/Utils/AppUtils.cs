using Domain.Constants;
using Domain.EnumEntities;

namespace Domain.Utils;

public class AppUtils
{
    public static uint GetActionColorHex(ColorEnum color)
    {
        switch (color)
        {
            case ColorEnum.Red:
                return ColorConstant.Red;
            case ColorEnum.Green:
                return ColorConstant.Green;
            case ColorEnum.Blue:
                return ColorConstant.Blue;
            case ColorEnum.Yellow:
            default:
                return ColorConstant.Yellow;
        }
    }
}