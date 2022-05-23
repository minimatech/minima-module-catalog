// using MediatR;
// using Minima.Platform.Domain.Data;
//
// namespace Minima.CatalogCore.Api.Queries.Handlers
// {
//     public class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, Vendor>
//     {
//         private readonly IRepository<Vendor> _vendorRepository;
//
//         public GetVendorByIdQueryHandler(IRepository<Vendor> vendorRepository)
//         {
//             _vendorRepository = vendorRepository;
//         }
//
//         public Task<Vendor> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
//         {
//             if (string.IsNullOrWhiteSpace(request.Id))
//                 return Task.FromResult<Vendor>(null);
//
//             return _vendorRepository.GetByIdAsync(request.Id);
//         }
//     }
// }
