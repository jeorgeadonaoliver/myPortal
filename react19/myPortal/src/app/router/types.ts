import type { RouteObject } from "react-router-dom";

export interface AppRoute extends Omit<RouteObject, "children"> {
  protected?: boolean;
  children?: AppRoute[];
}