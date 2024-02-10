'use client';

import * as React from 'react';
import {QueryClient, QueryClientProvider} from '@tanstack/react-query'

const queryClient = new QueryClient()
const Providers: React.FC<{ children: React.ReactNode }> = ({children}) => {
    return (
        <React.Fragment>
            <QueryClientProvider client={queryClient}>
                {children}
            </QueryClientProvider>
        </React.Fragment>
    );
};

export default Providers