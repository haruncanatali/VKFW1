using System.ComponentModel.DataAnnotations;

namespace VKFW1.Api.Models;

public class CustomerUpdateRequestModel
{
    [Required(ErrorMessage = "Id alanı zorunludur.")]
    public long Id { get; set; }
    [Required(ErrorMessage = "Ad alanı zorunludur.")]
    [MaxLength(100,ErrorMessage = "Ad alanı en fazla 100 karakter olabilir.")] 
    public string Name { get; set; }
    [Required(ErrorMessage = "Soyad alanı zorunludur.")]
    [MaxLength(100,ErrorMessage = "Soyad alanı en fazla 100 karakter olabilir.")]
    public string Surname { get; set; }
}