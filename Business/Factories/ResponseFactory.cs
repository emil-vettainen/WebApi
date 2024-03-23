﻿using Business.Helper.Responses.Enums;
using Business.Helper.Responses;

namespace Business.Factories;

public class ResponseFactory
{
    public static ResponseResult Ok()
    {
        return new ResponseResult
        {

            Message = "Succeded",
            StatusCode = ResultStatus.OK,
        };
    }
    public static ResponseResult Ok(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Succeded",
            StatusCode = ResultStatus.OK,
        };
    }

    public static ResponseResult Ok(object obj, string? message = null)
    {
        return new ResponseResult
        {
            ContentResult = obj,
            Message = message ?? "Succeded",
            StatusCode = ResultStatus.OK,
        };
    }

    public static ResponseResult Error(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Something went wrong, please try again.",
            StatusCode = ResultStatus.ERROR,
        };
    }

    public static ResponseResult NotFound(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Not found",
            StatusCode = ResultStatus.NOT_FOUND,
        };
    }

    public static ResponseResult Exists(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Already exists",
            StatusCode = ResultStatus.EXISTS,
        };
    }
}
