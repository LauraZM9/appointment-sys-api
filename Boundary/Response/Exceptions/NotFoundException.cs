using System;
// using FluentValidation.Results;

namespace appointment_sys_api.Boundary.Response.Exceptions;
public class NotFoundException : Exception
{

    public NotFoundException(string message) : base(message) { }
}