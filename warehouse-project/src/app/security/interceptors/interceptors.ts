import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { verifySessionInterceptor } from "./verifySession.interceptor";
import { JwtInterceptor } from "./jwt.interceptor";

export const InterceptorsProviders = [
  { provider: HTTP_INTERCEPTORS,
    useClass: JwtInterceptor,
    multi: true
  },
  {
    provider: HTTP_INTERCEPTORS,
    useClass: verifySessionInterceptor,
    multi: true

  },
];
