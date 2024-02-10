import { useRouter } from 'next/navigation';
import { useContext } from 'react';

import {
  DefaultError,
  QueryClient,
  UseMutationOptions,
  UseMutationResult,
  useMutation,
} from '@tanstack/react-query';
import Cookies from 'js-cookie';
import { AxiosError } from 'axios';
import AuthApiManager from '@/api/managers/AuthApiManager';
import { COOKIES } from '@/api/apiConsts';
import { useState } from 'react';

export function usePostRequest<
  TData = any,
  TError = DefaultError,
  TVariables = void,
  TContext = unknown
>(
  options: UseMutationOptions<TData, TError, TVariables, TContext>,
  queryClient?: QueryClient
): UseMutationResult<TData, TError, TVariables, TContext> {
  const router = useRouter();
  const [lastData, setLastData] = <any>useState();

  const mutation = useMutation({
    ...options,
    onError(error, variables, context) {
      console.log(variables);
      if (error instanceof AxiosError && error.response?.status === 403) {
        // const refreshToken = Cookies.get(COOKIES.REFRESH);
        // if (refreshToken) {
        //   setLastData(variables);
        //   refreshMutation.mutate({ refreshToken: refreshToken });
        // }
        router.push('/login');
      }
      if (options.onError) {
        options?.onError(error, variables, context);
      }
    },
  });

  // const refreshMutation = useMutation({
  //   mutationFn: (variables: { refreshToken: string }) => {
  //     return AuthApiManager.refresh(variables);
  //   },
  //
  //   onError: (error, variables, context) => {
  //     Cookies.remove(COOKIES.ACCESS);
  //     Cookies.remove(COOKIES.REFRESH);
  //     router.push('/logIn');
  //   },
  //   onSuccess: (data, variables, context) => {
  //     Cookies.set(COOKIES.ACCESS, data.data['access_token']);
  //     Cookies.set(COOKIES.REFRESH, data.data['refresh_token']);
  //     mutation.mutate(lastData);
  //   },
  // });

  return mutation;
}
