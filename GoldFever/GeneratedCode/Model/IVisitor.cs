using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace GoldFever.GeneratedCode.Model
{
    public interface IVisitor
    {
        void Visit(Track visitee);

        void Visit(Boat visitee);

        void Visit(Cart visitee);

        void Visit(OutgoingSwitch visitee);

        void Visit(IncomingSwitch visitee);

        void Visit(NoCollisionTrack visitee);

        void Visit(Warehouse<Boat> visitee);

        void Visit(Warehouse<Cart> visitee);

        void Visit(Dock visitee);


    }
}
