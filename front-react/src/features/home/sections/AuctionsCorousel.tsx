import * as React from 'react';
import Typography from "@mui/joy/Typography";
import Stack from "@mui/joy/Stack";
import {AuctionCarouselItem} from "@/features/home/sections/components/AuctionCarouselItem";


export const AuctionsCorousel = () => {
    return (
        <section style={{
            height: '100lvh',
            display: 'flex',
            flexDirection: 'column',
            justifyContent: 'center',
            alignItems: 'center',
        }}>
            <Typography level={'h3'}>The Most Sought-After Auctions</Typography>
            <Stack>
                <AuctionCarouselItem />
            </Stack>
        </section>
    );
};