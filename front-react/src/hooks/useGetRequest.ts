import { useMutation, useQuery } from '@tanstack/react-query';
import { useRouter } from 'next/navigation';
import Cookies from 'js-cookie';
import React from 'react';
import { AuthApiMananger } from '../../../api/manangers/AuthApiMananger';
import { COOKIES } from '@/api/apiConsts';
import { AxiosError } from 'axios';

export function useGetRequest({
  queryKey,
  queryFn,
  params,
  enabled,
  select,
  ...props
}: {
  queryKey: string | object | undefined;
  queryFn: Function;
  params?: object;
  enabled?: boolean;
  select?: ((data: any) => any) | undefined;
  props?: any;
}) {
  const router = useRouter();

  const request = useQuery({
    ...props,
    enabled: enabled,
    queryKey: [queryKey, params],
    queryFn: () => {
      return params ? queryFn(params) : queryFn();
    },
    select: select,
  });
  const refreshMutation = useMutation({
    mutationFn: (variables: { refreshToken: string }) => {
      return AuthApiMananger.refresh(variables);
    },
    onError: (error, variables, context) => {
      Cookies.remove(COOKIES.ACCESS);
      Cookies.remove(COOKIES.REFRESH);
      router.push('/logIn');
    },
    onSuccess: (data, variables, context) => {
      Cookies.set(COOKIES.ACCESS, data.data['access_token']);
      Cookies.set(COOKIES.REFRESH, data.data['refresh_token']);
      request.refetch();
    },
  });

  React.useEffect(() => {
    // console.log(request.error);
    if (
      request.error instanceof AxiosError &&
      request.error.response?.status == 403
    ) {
      const refreshToken = Cookies.get(COOKIES.REFRESH);
      if (refreshToken) {
        refreshMutation.mutate({ refreshToken: refreshToken });
      } else {
        router.push('/logIn');
      }
    }
  }, [request.error]);
  return request;
}
