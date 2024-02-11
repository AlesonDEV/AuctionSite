import React from 'react';
import {ListItem, Sheet} from "@mui/joy";
import Box from "@mui/joy/Box";
import Typography from "@mui/joy/Typography";
import ButtonLink from "@/features/home/sections/components/ButtonLink";
import {IAuction, randomImageUrl} from "@/features/auctions/api/AuctionsApiManager";

const AuctionListitem: React.FC<{auction: IAuction}> = ({auction}) => {
    return (
        <ListItem
            sx={{
                display: 'flex',
                justifyContent: 'start',
                maxWidth: '70rem',
                padding: '1rem',
            }}
        >
            <Sheet
                sx={{
                    // transition: 'all 1s',
                    // '& :hover' : {
                    padding: '0.4rem 0.8rem 0.4rem 0',
                    // }
                }}
                variant={'soft'}
            >
                {/*<Box*/}
                {/*    sx={{*/}
                {/*        width: '10rem',*/}
                {/*        height: '10rem',*/}
                {/*        background: 'white',*/}
                {/*        borderRadius: '8px',*/}
                {/*    }}*/}
                {/*></Box>*/}
                <img
                    src={randomImageUrl}
                    style={{
                        width: '10rem',
                        height: '10rem',
                        borderRadius: '8px',
                        backgroundColor: 'white',
                    }}
                    alt={''}
                />
            </Sheet>
            <Box sx={{width: '20rem',}}>
                <Typography level={'h3'}>{auction.title}</Typography>
                <Typography>Bids size: {auction.currentBid}</Typography>
                {/*<Typography>{auction.}</Typography>*/}
                <Box sx={{
                    display: 'flex',
                    justifyContent: 'flex-end',

                }}>
                    <ButtonLink href={'/auctions/'+auction.auctionId}>Go to Auction</ButtonLink>
                </Box>
            </Box>
        </ListItem>
    );
};

export default AuctionListitem;
