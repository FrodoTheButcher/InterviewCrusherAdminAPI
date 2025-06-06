﻿using InterviewCrusherAdmin.CommonDomain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InterviewCrusherAdmin
{
  public static class ControllerBaseExtension
  {
    public static IActionResult Created(this ControllerBase controller, Response result)
    {
      return controller.StatusCode(201, result);
    }
    public static IActionResult ToActionResult(this ControllerBase controller, Response result)
    {
      if (result.StatusCode == System.Net.HttpStatusCode.OK)
      {
        return controller.Ok(result);
      }
      else if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
      {
        return controller.BadRequest(result);
      }
      else if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
      {
        return controller.NotFound(result);
      }
      else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
      {
        return controller.StatusCode(500, result);
      }
      else if (result.StatusCode == System.Net.HttpStatusCode.Created)
      {
        return controller.Created(result);
      }
      else
      {
        return controller.StatusCode(500, result);
      }
    }
  }
}
