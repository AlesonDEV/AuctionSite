import React from 'react';
import Box from "@mui/joy/Box";
import {Divider, List, ListItem, Sheet} from "@mui/joy";
// import Typography from "@mui/joy/Typography";
// import ButtonLink from "@/features/home/sections/components/ButtonLink";
import AuctionListItem from "@/features/auctions/components/AuctionListItem";
import AuctionsApiManager from "@/features/auctions/api/AuctionsApiManager";


const Bulk = async () => {
    const AuctionData = await AuctionsApiManager.getAuctions({count: 10})

    return (
        <section>
            <Box sx={{
                flex: '1',
                width: '100vw',
                minHeight: '100vh',
                padding: '2rem',
            }}>
                <List>
                    {
                        AuctionData.data.map(auction => (
                            <React.Fragment key={auction.auctionId}>
                                <AuctionListItem auction={auction}/>
                                <Divider
                                    sx={{
                                        maxWidth: '50rem'
                                    }}
                                />
                            </React.Fragment>
                        ))
                    }

                    {/*<AuctionListItem />*/}
                </List>
            </Box>
        </section>
    )
        ;
};

export default Bulk;
