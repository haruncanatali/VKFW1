using System.ComponentModel.DataAnnotations;
using VKFW1.Api.Enums;

namespace VKFW1.Api.Models;

public class CustomerCreateRequestModel
{
    [Required(ErrorMessage = "Ad alanı zorunludur.")]
    [MaxLength(100,ErrorMessage = "Ad alanı en fazla 100 karakter olabilir.")] 
    public string Name { get; set; }
    [Required(ErrorMessage = "Soyad alanı zorunludur.")]
    [MaxLength(100,ErrorMessage = "Soyad alanı en fazla 100 karakter olabilir.")]
    public string Surname { get; set; }
    [Required(ErrorMessage = "TCKN alanı zorunludur.")]
    [MaxLength(100,ErrorMessage = "TCKN alanı en fazla 100 karakter olabilir.")]
    public string IdentificationNumber { get; set; }
    [Required(ErrorMessage = "Adres alanı zorunludur.")]
    [MaxLength(100,ErrorMessage = "Adres alanı en fazla 500 karakter olabilir.")]
    public string Address { get; set; }
    [Required(ErrorMessage = "Yaş alanı zorunludur.")]
    public int Age { get; set; }
    [Required(ErrorMessage = "Cinsiyet alanı zorunludur.")]
    public Gender Gender { get; set; }
}