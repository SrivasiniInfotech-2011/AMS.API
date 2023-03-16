﻿using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class CreateApartment
    {
        public class Command : IRequest<Apartment>
        {
            public Command(Apartment apartment)
            {
                Apartment = apartment;
            }

            public Apartment Apartment { get; }

        }

        public class Handler : IRequestHandler<Command,Apartment>
        {
            private readonly IApartmentRepository ApartmentRepository;

            public Handler(IApartmentRepository apartmentRepository)
            {
                this.ApartmentRepository = apartmentRepository;
            }

            public async Task<Apartment> Handle(Command message, CancellationToken cancellationToken)
            {
                return await ApartmentRepository.InsertApartment(message.Apartment);

            }
        }
    }
}
