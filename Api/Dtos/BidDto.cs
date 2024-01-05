using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public record BidDto(
    int Id,
    int HouseId,
    [property: Required] string Bidder,
    int Amount
);
