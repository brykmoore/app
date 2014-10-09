using System;

namespace app.startup
{
  public delegate IRunAStartupStep ICreateStartupSteps(Type step_type);
}