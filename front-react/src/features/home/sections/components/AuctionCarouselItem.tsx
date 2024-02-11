import * as React from 'react';
import {Card} from "@mui/joy";
import Box from "@mui/joy/Box";
import ButtonLink from "@/features/home/sections/components/ButtonLink";
import Typography from "@mui/joy/Typography";
import type {IAuction} from "@/features/auctions/api/AuctionsApiManager";
import {randomImageUrl} from "@/features/auctions/api/AuctionsApiManager";

export const AuctionCarouselItem: React.FC<{ auction: IAuction }> = ({auction}) => {
    return (
        <Card
            sx={{
                padding: '1rem 2rem'
            }}
            variant={'soft'}
        >
            <img
                src={randomImageUrl}
                style={{
                    width: '12rem',
                    height: '12rem',
                    borderRadius: '8px',
                    backgroundColor: 'white',
                    position: 'relative',
                    bottom: "4rem",
                }}
            />
            <Box sx={{
                margin: '-3rem 0 1rem 0',
            }}>
                <Typography level={"h3"}>
                    {auction.title}
                </Typography>
                <Typography level={"title-md"}>
                    Current bid: {auction.currentBid}
                </Typography>
            </Box>
            <ButtonLink
                href={'/auctions/' + auction.auctionId}
                size={'md'}
                color={'neutral'}
                variant={'outlined'}
            >Go to auction</ButtonLink>
        </Card>
    );
};