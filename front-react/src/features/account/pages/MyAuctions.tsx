'use client';

import React from 'react';
import {useGetRequest} from "@/hooks/useGetRequest";
import type {IAuction} from "@/features/auctions/api/AuctionsApiManager";
import Cookies from "js-cookie";
import {COOKIES} from "@/api/apiConsts";
import AuctionsApiManager from "@/features/auctions/api/AuctionsApiManager";
import Box from "@mui/joy/Box";
import {List} from "@mui/joy";
import Loader from "@/components/Loader";
import AuctionListItem from "@/features/auctions/components/AuctionListItem";
const MyAuctions = () => {
    const UserEmail: string = Cookies.get(COOKIES.EMAIL) as string
    const AuctionsData = useGetRequest<IAuction[]>({
        queryKey: ['getAuctions', UserEmail],
        queryFn: AuctionsApiManager.getUserAuctions,
        params: {
            email: UserEmail
        },
        select: data => data.data as IAuction[]
    })
    return (
        <Box>
            <List>
                <Loader isLoading={AuctionsData.isLoading}>
                    {
                        AuctionsData.data?.map(auction => (
                            <AuctionListItem auction={auction}/>
                        ))
                    }
                </Loader>
            </List>
        </Box>
    );
};

export default MyAuctions;
