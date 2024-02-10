import * as React from 'react';
import {Card} from "@mui/joy";
import Box from "@mui/joy/Box";
import ButtonLink from "@/features/home/sections/components/ButtonLink";
import Typography from "@mui/joy/Typography";

export const AuctionCarouselItem = () => {
    return (
        <Card
            sx={{
                padding: '1rem 2rem'
            }}
            variant={'soft'}
        >
            <Box sx={{
                width: '12rem',
                height: '12rem',
                borderRadius: '8px',
                backgroundColor: 'white',
                position: 'relative',
                bottom: "4rem",
            }}></Box>
            <Box sx={{
                margin: '-3rem 0 1rem 0',
            }}>
                <Typography level={"h3"}>
                    Lorem Ipsum
                </Typography>
            </Box>
            <ButtonLink
                href={'/auctions/1'}
                size={'md'}
                color={'neutral'}
                variant={'outlined'}
            >Go to auction</ButtonLink>
        </Card>
    );
};