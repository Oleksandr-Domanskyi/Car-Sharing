using CarSharingApplication.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.Queries.GetByNameCarSharing
{
    public class GetByNameCarSharingQuery:IRequest<ShowCarSharingProfileModelObject>
    {
        public Guid Id { get; set; }

        public GetByNameCarSharingQuery(Guid id)
        {
            Id = id;
        }
    }
}
