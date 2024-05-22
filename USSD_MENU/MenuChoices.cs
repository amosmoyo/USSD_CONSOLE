using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USSD_MENU
{
    public enum MenuChoices
    {
        [Description("Balance Check")]
        balance,

        [Description("Ministatement Check")]
        ministatement,

        [Description("FullStatement Check")]
        fullstatement,

        [Description("Ext")]
        exit,

        [Description("Unknown Option")]
        Unknown

    }
}
