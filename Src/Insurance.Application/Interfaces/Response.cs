using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Interfaces;

public record Response
{
}
public record CommandResponse : Response
{
    public bool Succeeded { get; }
    public string[]? Errors { get; protected set; } = null;
    protected internal CommandResponse()
    {

    }
    protected internal CommandResponse(bool success)
    {
        this.Succeeded = success;
    }

    public static CommandResponse Success() => new CommandResponse(true);
    public static CommandResponse Faild() => new CommandResponse(false);
    public static CommandResponse Faild(string[] errors) => new CommandResponse(false) { Errors = errors };
};
public record CommandResponse<TData> : CommandResponse
{
    protected internal CommandResponse() : base(false)
    {
    }

    protected internal CommandResponse(bool success) : base(success)
    {
    }

    protected internal CommandResponse(bool success, TData data) : base(success)
    {
        Data = data;
    }

    public static CommandResponse<TData> Success(TData data) => new CommandResponse<TData>(true, data);
    public static new CommandResponse<TData> Faild() => new CommandResponse<TData>(false);
    public static new CommandResponse<TData> Faild(string[] errors) => new CommandResponse<TData>(false) { Errors = errors };
    public TData Data { get; set; }

};
