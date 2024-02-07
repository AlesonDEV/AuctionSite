import * as React from 'react';
import {Card} from "@mui/joy";
import Box from "@mui/joy/Box";
import ButtonLink from "@/features/home/sections/components/ButtonLink";

export const AuctionCarouselItem = () => {
    return (
        <Card
            sx={{
                padding: '2rem 4rem'
            }}
            variant={'soft'}
        >
            <Box sx={{
                width: '10rem',
                height: '10rem',
                borderRadius: '8px',
                backgroundColor: 'white'
            }}></Box>
            <Box></Box>
            <ButtonLink
                href={'/auctions/1'}
                size={'md'}
                color={'neutral'}
                variant={'outlined'}
            >Go to auction</ButtonLink>
        </Card>
    );
};