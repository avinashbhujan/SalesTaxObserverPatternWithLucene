using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxObserverPattern
{
    public abstract class Observer
    {
        public TransactionManager transactionManager;

        public virtual void update() { }
    }
}
