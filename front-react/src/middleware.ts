import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';
import { COOKIES } from './api/apiConsts';

export function middleware(request: NextRequest) {
  if (request.nextUrl.pathname === '/account') {
    return NextResponse.redirect(new URL('/dashboard', request.url));
  }
  if (
      request.nextUrl.pathname === '/account'
      && (
          !request.cookies.get(COOKIES.ACCESS) ||
          !request.cookies.get(COOKIES.REFRESH)
      )
  ) {
    return NextResponse.redirect(new URL('/login', request.url));
  }
  return NextResponse.next();
}
export const config = {
  matcher: ['/((?!api|_next/static|_next/image|favicon.ico|logIn).*)'],
};
