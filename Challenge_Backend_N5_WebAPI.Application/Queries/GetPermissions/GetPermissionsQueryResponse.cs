namespace Challenge_Backend_N5_WebAPI.Application.Queries.GetPermissions
{
    public class GetPermissionsQueryResponse
    {
        public long Id { get; set; }
        public string? NombreEmpleado { get; set; }

        public string? ApellidoEmpleado { get; set; }

        public DateTime FechaPermiso { get; set; }

        public long TypeId { get; set; }
    }
}
