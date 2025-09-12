import { createBrowserRouter, RouterProvider, type RouteObject } from "react-router-dom";
import type { AppRoute } from "./types";
import { routes } from "./routes";
import { ProtectedRoute } from "./ProtectedRoutes";

const mapRoutes = (routeList: AppRoute[]): RouteObject[] =>
  routeList.map((r) => {
    if (r.index) {
      // Index route: no path allowed
      return {
        index: true,
        element: r.protected
          ? <ProtectedRoute>{r.element}</ProtectedRoute>
          : r.element,
      };
    }

    // Non-index route: must have path
    return {
      path: r.path,
      element: r.protected
        ? <ProtectedRoute>{r.element}</ProtectedRoute>
        : r.element,
      children: r.children ? mapRoutes(r.children) : undefined,
    };
  });

const router = createBrowserRouter(mapRoutes(routes));

export const AppRouter = () => <RouterProvider router={router} />;