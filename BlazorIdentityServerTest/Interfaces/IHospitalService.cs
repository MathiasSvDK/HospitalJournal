using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Interfaces;

public interface IHospitalService
{
    HospitalContext _hospitalContext { get; set; }

    ///<summary>
    /// Get all of the hospitals
    /// <returns>All hospitals</returns>
    /// </summary>
    List<Hospital> Get();

    ///<summary>
    /// Get a hospital by a specific id
    ///<param name="id">ID of a hospital</param>
    /// <returns>A Hospital</returns>
    /// </summary>
    Hospital Get(int id);

    ///<summary>
    /// Update a hospital with new values
    ///<param name="hospital">The hospital that has to be updated with updated values</param>
    /// </summary>
    void Update(Hospital hospital);

    ///<summary>
    /// Save the changes to the database
    /// </summary>
    void Save();
}