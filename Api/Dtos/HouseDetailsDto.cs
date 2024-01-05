using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public record HouseDetailsDto(
    int Id,
    [property: Required] string? Address,
    [property: Required] string? Country,
    int Price,
    string? Description,
    string? Photo);
