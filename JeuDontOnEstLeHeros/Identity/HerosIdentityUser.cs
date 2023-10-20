using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace JeuDontEstLeHeros.Core.Models.Identity;

// Add profile data for application users by adding properties to the HerosIdentityUser class
/// <summary>
/// modification de IdentityUser / pour la prise en charge de role comme par exemple d'administrateur / utilisateur
/// les comptes admin ne peuvent venir sur le back
/// mise ne place de identity au niveau du back
/// /// </summary>
public class HerosIdentityUser : IdentityUser
{

}

