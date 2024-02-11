'use client';

import * as React from 'react';
import Typography from "@mui/joy/Typography";
import Stack from "@mui/joy/Stack";
import {AuctionCarouselItem} from "@/features/home/sections/components/AuctionCarouselItem";
import {useGetRequest} from "@/hooks/useGetRequest";
import AuctionsApiManager from "@/features/auctions/api/AuctionsApiManager";
import {IAuction} from "@/features/auctions/api/AuctionsApiManager";
import Loader from "@/components/Loader";

export const AuctionsCorousel = () => {
    const AuctionsData = useGetRequest<IAuction[]>({
        queryKey: ['getAuctions'],
        queryFn: AuctionsApiManager.getAuctions,
        params: {count: 3},
        select: data => data.data as IAuction[]
    })

    return (
        <section style={{
            height: '40rem',
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            alignItems: 'center',
            gap: '5rem',
        }}>
            <Typography
                level={'h1'}
                color={'success'}
            >The Most Sought-After Auctions</Typography>
            <Stack direction={'row'} spacing={'2rem'}>
                <Loader isLoading={AuctionsData.isLoading}>
                    {

                        AuctionsData.data?.map((auction: IAuction) => (
                            <AuctionCarouselItem
                                auction={auction}
                                key={auction.auctionId}
                            />
                        ))

                    }
                </Loader>
            </Stack>
        </section>
    );
};