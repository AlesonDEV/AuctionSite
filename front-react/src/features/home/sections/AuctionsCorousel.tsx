import * as React from 'react';
import Typography from "@mui/joy/Typography";
import Stack from "@mui/joy/Stack";
import {AuctionCarouselItem} from "@/features/home/sections/components/AuctionCarouselItem";


export const AuctionsCorousel = () => {
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
            <Stack direction={'row'} spacing={'2rem'} >
                <AuctionCarouselItem/>
                <AuctionCarouselItem/>
                <AuctionCarouselItem/>
            </Stack>
        </section>
    );
};